using Core.Models;
using StateManagerPattern.Interfaces;
using StateManagerPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagerPattern.States
{
    public class ConnectedState : BaseState
    {
        private const char ACTION_CHAR = 'd';
        private const int MAX_PACKETS_DROPPED = 3;
        private int _packetsDropped = 0;

        public ConnectedState()
        {
            AddTransitionRule(new Rule(ConnectionState.Disconnected, (key) => key == ACTION_CHAR));
            AddTransitionRule(new Rule(ConnectionState.Disconnected, (key) => DropTest(key)));
        }

        public override string Name => "Connected (Press 'd' to transition to Disconnected or enter 3 other keys)";

        private bool DropTest(char key)
        {
            if (key != ACTION_CHAR)
            {
                _packetsDropped++;
            }

            return _packetsDropped >= MAX_PACKETS_DROPPED;
        }
    }
}
