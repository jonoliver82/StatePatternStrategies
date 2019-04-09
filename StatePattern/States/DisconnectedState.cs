using StatePattern.Interfaces;
using StatePattern.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    public class DisconnectedState : ITestState
    {
        private const char KEY_CONNECT = 'C';

        private readonly IStateTransitionStrategy _stateTransitionStrategy;

        public DisconnectedState(IStateTransitionStrategy stateTransitionStrategy)
        {
            _stateTransitionStrategy = stateTransitionStrategy;
        }

        public string Name => "Disconnected";

        public int Order => 1;

        public void HandleKeyPress(IConnectionService connectionService, char key)
        {
            if (char.ToUpper(key, CultureInfo.InvariantCulture) == KEY_CONNECT)
            {
                _stateTransitionStrategy.MoveToState(connectionService, ConnectionState.Connected);                
            }
        }
    }
}
