using StatePattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatePattern.Events;
using StatePattern.Models;

namespace StatePattern.Strategies
{
    public class SequentialStateTransitionStrategy : IStateTransitionStrategy
    {
        // Not required in this strategy
        public event EventHandler<StateTransitionEventArgs> ChangeState;

        public string Name => "SequentialState";

        // Parameter not required in this strategy
        public void MoveToState(IConnectionService connectionService, ConnectionState desiredState)
        {
            connectionService.MoveToNextState();
        }
    }
}
