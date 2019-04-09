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
    public class ConnectedState : ITestState
    {
        private const char KEY_DISCONNECT = 'D';

        private readonly IStateTransitionStrategy _stateTransitionStrategy;

        public ConnectedState(IStateTransitionStrategy stateTransitionStrategy)
        {
            _stateTransitionStrategy = stateTransitionStrategy;
        }

        public string Name => "Connected";

        public int Order => 2;

        public void HandleKeyPress(IConnectionService connectionService, char key)
        {
            if (char.ToUpper(key, CultureInfo.InvariantCulture) == KEY_DISCONNECT)
            {
                _stateTransitionStrategy.MoveToState(connectionService, ConnectionState.Disconnected);
            }
        }
    }
}
