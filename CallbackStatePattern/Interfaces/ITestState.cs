using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackStatePattern.Interfaces
{
    public interface ITestState
    {
        string Name { get; }

        void HandleKeyPress(IConnectionService connectionService, char key);
    }
}
