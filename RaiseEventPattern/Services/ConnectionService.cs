using Core.Events;
using Core.Interfaces;
using Core.Services;
using RaiseEventPattern.Interfaces;

namespace RaiseEventPattern.Services
{
    public class ConnectionService : ConnectionServiceBase, IConnectionService
    {
        public ConnectionService(IStateFactory stateFactory, ILogger logger)
            : base(stateFactory, logger)
        {
            ((ITestState)_currentState).ChangeState += _currentState_ChangeState;
        }

        private void _currentState_ChangeState(object sender, StateTransitionEventArgs e)
        {
            // Unsubscribe from current state object
            ((ITestState)_currentState).ChangeState -= _currentState_ChangeState;

            MoveToState(e.DesiredState);

            // Subscribe to new state object
            ((ITestState)_currentState).ChangeState += _currentState_ChangeState;
        }
    }
}
