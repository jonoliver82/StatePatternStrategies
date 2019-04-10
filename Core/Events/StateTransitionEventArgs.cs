using Core.Models;
using System;

namespace Core.Events
{
    public class StateTransitionEventArgs : EventArgs
    {
        public StateTransitionEventArgs(ConnectionState desiredState)
        {
            DesiredState = desiredState;
        }

        public ConnectionState DesiredState { get; }
    }
}
