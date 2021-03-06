﻿using StatePattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Events
{
    public class StateTransitionEventArgs : EventArgs
    {
        public StateTransitionEventArgs(ConnectionState desiredState)
        {
            DesiredState = desiredState;
        }

        public ConnectionState DesiredState { get; }
    }
}
