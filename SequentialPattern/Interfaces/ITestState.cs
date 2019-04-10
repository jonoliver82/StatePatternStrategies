using Core.Interfaces;
using Core.Models;

namespace SequentialPattern.Interfaces
{
    public interface ITestState : ITestStateBase
    {
        ConnectionState State { get; }

        int Order { get; }
    }
}
