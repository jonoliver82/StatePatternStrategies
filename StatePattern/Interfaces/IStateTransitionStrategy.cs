using StatePattern.Events;
using StatePattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Interfaces
{
    public interface IStateTransitionStrategy
    {
        string Name { get; }

        event EventHandler<StateTransitionEventArgs> ChangeState;

        void MoveToState(IConnectionService connectionService, ConnectionState desiredState);
    }
}
