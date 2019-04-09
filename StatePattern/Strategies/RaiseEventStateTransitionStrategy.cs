using StatePattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatePattern.Models;
using StatePattern.Events;

namespace StatePattern.Strategies
{
    public class RaiseEventStateTransitionStrategy : IStateTransitionStrategy
    {
        public event EventHandler<StateTransitionEventArgs> ChangeState;

        public string Name => "RaiseEvent";

        public void MoveToState(IConnectionService connectionService, ConnectionState desiredState)
        {
            // Directly publish an event to any subscribers, including the controller
            ChangeState?.Invoke(this, new StateTransitionEventArgs(desiredState));
        }
    }
}
