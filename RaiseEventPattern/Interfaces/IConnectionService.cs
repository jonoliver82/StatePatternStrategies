using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiseEventPattern.Interfaces
{
    public interface IConnectionService
    {
        bool Continue { get; }

        void HandleKeyPress(char key);
    }
}
