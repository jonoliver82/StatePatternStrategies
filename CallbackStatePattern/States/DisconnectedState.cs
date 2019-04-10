using CallbackStatePattern.Interfaces;
using Core.Interfaces;
using Core.Models;
using System.Globalization;

namespace CallbackStatePattern.States
{
    public class DisconnectedState : ITestState
    {
        private const char KEY_CONNECT = 'C';

        public string Name => "Disconnected";

        public void HandleKeyPress(IConnectionServiceBase connectionService, char key)
        {
            if (char.ToUpper(key, CultureInfo.InvariantCulture) == KEY_CONNECT)
            {
                connectionService.MoveToState(ConnectionState.Connected);
            }
        }
    }
}
