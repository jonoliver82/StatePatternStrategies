using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    public abstract class ConnectionServiceBase : IConnectionServiceBase
    {
        protected readonly ILogger _logger;
        private readonly IStateFactory _stateFactory;
        protected bool _continue;

        protected ITestStateBase _currentState;

        public ConnectionServiceBase(IStateFactory stateFactory, ILogger logger)
        {
            _stateFactory = stateFactory;               
            _logger = logger;

            _currentState = stateFactory.Create(ConnectionState.Disconnected);
            _continue = true;
        }

        public bool Continue => _continue;

        protected IStateFactory StateFactory => _stateFactory;

        public void HandleKeyPress(char key)
        {
            _currentState.HandleKeyPress(this, key);
            LogCurrentState();
        }

        public void MoveToState(ConnectionState desiredState)
        {
            _currentState = _stateFactory.Create(desiredState);
        }

        protected void LogCurrentState()
        {
            _logger.Log("\nCurrent State: " + _currentState.Name);
        }
    }
}
