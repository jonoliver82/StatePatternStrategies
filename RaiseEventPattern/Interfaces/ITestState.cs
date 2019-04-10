﻿using Core.Events;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiseEventPattern.Interfaces
{
    public interface ITestState : ITestStateBase
    {
        event EventHandler<StateTransitionEventArgs> ChangeState;
    }
}
