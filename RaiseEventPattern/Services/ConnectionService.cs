using Core.Events;
using Core.Interfaces;
using Core.Models;
using RaiseEventPattern.Interfaces;
using RaiseEventPattern.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiseEventPattern.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly ILogger _logger;
        private bool _continue;
        private ITestState _currentState;

        public ConnectionService(ILogger logger)
        {
            _logger = logger;

            _currentState = new DisconnectedState();
            _currentState.ChangeState += _currentState_ChangeState;

            _continue = true;

            LogCurrentState();
        }

        private void _currentState_ChangeState(object sender, StateTransitionEventArgs e)
        {
            MoveToState(e.DesiredState);
        }

        public bool Continue => _continue;

        public void HandleKeyPress(char key)
        {
            _currentState.HandleKeyPress(key);
            LogCurrentState();
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
                        _currentState.ChangeState -= _currentState_ChangeState;
                        _currentState = new ConnectedState();
                        _currentState.ChangeState += _currentState_ChangeState;
                        break;
                    }
                case ConnectionState.Disconnected:
                    {
                        _currentState.ChangeState -= _currentState_ChangeState;
                        _currentState = new DisconnectedState();
                        _currentState.ChangeState += _currentState_ChangeState;
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
