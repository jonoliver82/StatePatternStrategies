﻿using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequentialPattern.Interfaces
{
    public interface IConnectionService : IConnectionServiceBase
    {
        void MoveToNextState();
    }
}
