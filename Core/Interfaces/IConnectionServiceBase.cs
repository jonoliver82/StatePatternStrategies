using Core.Models;

namespace Core.Interfaces
{
    public interface IConnectionServiceBase
    {
        bool Continue { get; }

        void HandleKeyPress(char key);

        void MoveToState(ConnectionState desiredState);
    }
}
