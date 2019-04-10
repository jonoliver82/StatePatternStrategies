using CallbackStatePattern.Interfaces;
using Core.Interfaces;
using Core.Models;
using System.Globalization;

namespace CallbackStatePattern.States
{
    public class ConnectedState : ITestState
    {
        private const char KEY_DISCONNECT = 'D';

        public string Name => "Connected";

        public void HandleKeyPress(IConnectionServiceBase connectionService, char key)
        {
            if (char.ToUpper(key, CultureInfo.InvariantCulture) == KEY_DISCONNECT)
            {
                connectionService.MoveToState(ConnectionState.Disconnected);
            }
        }
    }
}
