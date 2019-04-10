using Core.Interfaces;

namespace SequentialPattern.Interfaces
{
    public interface IConnectionService : IConnectionServiceBase
    {
        void MoveToNextState();
    }
}
