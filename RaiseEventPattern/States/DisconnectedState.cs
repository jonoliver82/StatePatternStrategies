using Core.Events;
using Core.Interfaces;
using Core.Models;
using RaiseEventPattern.Interfaces;
using System;

namespace RaiseEventPattern.States
{
    public class DisconnectedState : ITestState
    {
        public event EventHandler<StateTransitionEventArgs> ChangeState;

        public string Name => "Disconnected";

        public void HandleKeyPress(IConnectionServiceBase connectionService, char key)
        {
            ChangeState?.Invoke(connectionService, new StateTransitionEventArgs(ConnectionState.Connected));
        }
    }
}
