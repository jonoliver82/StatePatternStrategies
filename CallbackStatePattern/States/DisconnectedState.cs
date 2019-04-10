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
    public class DisconnectedState : ITestState
    {
        private const char KEY_CONNECT = 'C';

        public string Name => "Disconnected";

        public void HandleKeyPress(IConnectionService connectionService, char key)
        {
            if (char.ToUpper(key, CultureInfo.InvariantCulture) == KEY_CONNECT)
            {
                connectionService.MoveToState(ConnectionState.Connected);
            }
        }
    }
}
