using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IConnectionServiceBase
    {
        bool Continue { get; }

        void HandleKeyPress(char key);

        void MoveToState(ConnectionState desiredState);
    }
}
