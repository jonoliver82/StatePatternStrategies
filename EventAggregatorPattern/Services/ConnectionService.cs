using Core.Events;
using Core.Interfaces;
using Core.Models;
using EventAggregatorPattern.Interfaces;
using EventAggregatorPattern.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorPattern.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly ILogger _logger;
        private readonly IEventAggregatorService _eventAggregatorService;

        private ITestState _currentState;
        private bool _continue;

        public ConnectionService(ILogger logger, IEventAggregatorService eventAggregatorService)
        {
            _logger = logger;
            _eventAggregatorService = eventAggregatorService;

            _currentState = new DisconnectedState(_eventAggregatorService);

            // Subscribe to the event aggregator for state transition events
            _eventAggregatorService.Subscribe<StateTransitionEventArgs>(OnStateTransitionRequest);
            _continue = true;

            LogCurrentState();
        }

        public bool Continue => _continue;

        public void HandleKeyPress(char key)
        {
            _currentState.HandleKeyPress(key);
            LogCurrentState();
        }

        private void OnStateTransitionRequest(StateTransitionEventArgs e)
        {
            MoveToState(e.DesiredState);
        }

        private void LogCurrentState()
        {
            _logger.Log("\nCurrent State: " + _currentState.Name);
        }

        public void MoveToState(ConnectionState desiredState)
        {
            switch (desiredState)
            {
                case ConnectionState.Connected:
                    {
                        _currentState = new ConnectedState(_eventAggregatorService);
                        break;
                    }
                case ConnectionState.Disconnected:
                    {
                        _currentState = new DisconnectedState(_eventAggregatorService);
                        break;
                    }
                default:
                    {
                        _logger.Log($"Unexpected ConnectionState: {desiredState}");
                        break;
                    }
            }
        }
    }
}
