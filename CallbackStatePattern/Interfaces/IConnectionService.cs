using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace CallbackStatePattern.Interfaces
{
    public interface IConnectionService
    {
        bool Continue { get; }

        void HandleKeyPress(char key);

        void MoveToState(ConnectionState desiredState);
    }
}
