using StatePattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Interfaces
{
    public interface IConnectionService
    {
        bool Continue { get; }

        void HandleKeyPress(char key);

        void Exit();

        void MoveToState(ConnectionState desiredState);

        void MoveToNextState();    
    }
}
