using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Interfaces
{
    public interface ITestState
    {
        string Name { get; }

        int Order { get; }

        void HandleKeyPress(IConnectionService connectionService, char key);
    }
}
