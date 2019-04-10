using Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiseEventPattern.Interfaces
{
    public interface ITestState
    {
        event EventHandler<StateTransitionEventArgs> ChangeState;

        string Name { get; }

        void HandleKeyPress(char key);
    }
}
