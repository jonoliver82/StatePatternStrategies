using CallbackStatePattern.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackStatePattern.States
{
    public class ConnectedState : ITestState
    {
        private const char KEY_DISCONNECT = 'D';

        public string Name => "Connected";

        public void HandleKeyPress(IConnectionService connectionService, char key)
        {
            if (char.ToUpper(key, CultureInfo.InvariantCulture) == KEY_DISCONNECT)
            {
                connectionService.MoveToState(ConnectionState.Disconnected);
            }
        }
    }
}
