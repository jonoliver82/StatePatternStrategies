using CallbackStatePattern.Interfaces;
using CallbackStatePattern.States;
using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackStatePattern.Services
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
            _continue = true;

            LogCurrentState();
        }

        public bool Continue => _continue;

        public void HandleKeyPress(char key)
        {
            _currentState.HandleKeyPress(this, key);
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
                        _currentState = new ConnectedState();
                        break;
                    }
                case ConnectionState.Disconnected:
                    {
                        _currentState = new DisconnectedState();
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
