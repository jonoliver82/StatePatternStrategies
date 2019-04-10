using Core.Interfaces;
using Core.Models;
using SequentialPattern.Interfaces;

namespace SequentialPattern.States
{
    public class DisconnectedState : ITestState
    {
        public ConnectionState State => ConnectionState.Disconnected;

        public string Name => "Disconnected";

        public int Order => 1;

        public void HandleKeyPress(IConnectionServiceBase connectionService, char key)
        {
            ((IConnectionService)connectionService).MoveToNextState();
        }
    }
}
