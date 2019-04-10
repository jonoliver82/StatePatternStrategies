using Core.Events;
using Core.Interfaces;
using System;

namespace RaiseEventPattern.Interfaces
{
    public interface ITestState : ITestStateBase
    {
        event EventHandler<StateTransitionEventArgs> ChangeState;
    }
}
