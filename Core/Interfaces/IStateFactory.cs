using Core.Models;

namespace Core.Interfaces
{
    public interface IStateFactory
    {
        ITestStateBase Create(ConnectionState connectionState);
    }
}
