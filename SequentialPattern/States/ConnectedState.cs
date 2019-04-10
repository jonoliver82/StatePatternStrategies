using Core.Interfaces;
using Core.Models;
using SequentialPattern.Interfaces;

namespace SequentialPattern.States
{
    public class ConnectedState : ITestState
    {
        public ConnectionState State => ConnectionState.Connected;

        public string Name => "Connected";

        public int Order => 2;

        public void HandleKeyPress(IConnectionServiceBase connectionService, char key)
        {
            ((IConnectionService)connectionService).MoveToNextState();
        }
    }
}
