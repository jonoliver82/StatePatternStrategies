using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatePattern.Interfaces;
using StatePattern.Models;
using StatePattern.States;
using StatePattern.Events;
using StatePattern.Strategies;

namespace StatePattern.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly ILogger _logger;
        private readonly IStateTransitionStrategy _stateTransitionStrategy;
        private readonly IEventAggregatorService _eventAggregatorService;

        private IEnumerable<ITestState> _testStates;
        private ITestState _currentState;
        private bool _continue;
        private int _currentStateIndex = 0;

        public ConnectionService(ILogger logger, 
            IStateTransitionStrategy stateTransitionStrategy,
            IEventAggregatorService eventAggregatorService,
            IEnumerable<ITestState> testStates)
        {
            _logger = logger;
            _stateTransitionStrategy = stateTransitionStrategy;
            _eventAggregatorService = eventAggregatorService;
            _testStates = testStates;

            Initailise(_stateTransitionStrategy);
            LogCurrentState();
        }

        /// <summary>
        /// TODO move the logic for each strategy into own class, or create different versions of the ConnectionService class?
        /// TODO prefer enum over string name
        /// </summary>        
        private void Initailise(IStateTransitionStrategy stateTransitionStrategy)
        {
            switch(stateTransitionStrategy.Name)
            {
                case "CallbackToController":
                    {
                        _currentState = new DisconnectedState(_stateTransitionStrategy);
                        _continue = true;
                        break;
                    }
                case "EventAggregator":
                    {
                        _currentState = new DisconnectedState(_stateTransitionStrategy);
                        // Subscribe to the event aggregator for state transition events
                        _eventAggregatorService.Subscribe<StateTransitionEventArgs>(OnStateTransitionRequest);
                        _continue = true;
                        break;
                    }
                case "RaiseEvent":
                    {
                        _currentState = new DisconnectedState(_stateTransitionStrategy);
                        // Subscribe to the state transition for events
                        _stateTransitionStrategy.ChangeState += _stateTransitionStrategy_ChangeState;
                        _continue = true;
                        break;
                    }
                case "SequentialState":
                    {
                        // Sequential 
                        _testStates = _testStates.OrderBy(x => x.Order);
                        _currentState = _testStates.First();
                        _continue = true;
                        break;
                    }
                default:
                    {
                        _logger.Log("Unknown strategy: " + stateTransitionStrategy.Name);
                        _continue = false;
                        break;
                    }
            }
        }

        private void OnStateTransitionRequest(StateTransitionEventArgs e)
        {
            MoveToState(e.DesiredState);
        }

        private void _stateTransitionStrategy_ChangeState(object sender, StateTransitionEventArgs e)
        {
            MoveToState(e.DesiredState);
        }

        public bool Continue => _continue;

        public void Exit()
        {
            _continue = false;
        }

        public void HandleKeyPress(char key)
        {
            _currentState.HandleKeyPress(this, key);
            LogCurrentState();
        }

        /// <summary>
        /// Factory method to create a new state object of the desired state
        /// </summary>        
        public void MoveToState(ConnectionState desiredState)
        {            
            switch (desiredState)
            {
                case ConnectionState.Connected:
                    {
                        _currentState = new ConnectedState(_stateTransitionStrategy);
                        break;
                    }
                case ConnectionState.Disconnected:
                    {
                        _currentState = new DisconnectedState(_stateTransitionStrategy);
                        break;
                    }
                default:
                    {
                        _logger.Log($"Unexpected ConnectionState: {desiredState}");
                        break;
                    }
            }
        }

        public void MoveToNextState()
        {
            _currentStateIndex = (_currentStateIndex + 1) % _testStates.Count();
            _currentState = _testStates.ElementAt(_currentStateIndex);
        }

        private void LogCurrentState()
        {
            _logger.Log("Current State: " + _currentState.Name);
        }
    }
}
