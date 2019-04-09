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
    public class CallbackToControllerStateTransitionStrategy : IStateTransitionStrategy
    {        
        // Not used in this strategy
        public event EventHandler<StateTransitionEventArgs> ChangeState;

        public string Name => "CallbackToController";

        public void MoveToState(IConnectionService connectionService, ConnectionState desiredState)
        {
            // Directly call the controller class to manipulate the state
            connectionService.MoveToState(desiredState);
        }
    }
}
