using Core.Events;
using Core.Models;
using RaiseEventPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiseEventPattern.States
{
    public class ConnectedState : ITestState
    {
        public event EventHandler<StateTransitionEventArgs> ChangeState;

        public string Name => "Connected";

        public void HandleKeyPress(char key)
        {
            ChangeState?.Invoke(this, new StateTransitionEventArgs(ConnectionState.Disconnected));
        }
    }
}
