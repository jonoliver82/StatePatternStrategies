using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequentialPattern.Interfaces
{
    public interface ITestState : ITestStateBase
    {
        ConnectionState State { get; }

        int Order { get; }
    }
}
