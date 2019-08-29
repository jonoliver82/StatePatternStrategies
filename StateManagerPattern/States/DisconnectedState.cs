using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using StateManagerPattern.Models;

namespace StateManagerPattern.States
{
    public class DisconnectedState : BaseState
    {
        private const char ACTION_CHAR = 'c';

        public DisconnectedState()
        {            
            AddTransitionRule(new Rule(ConnectionState.Connected, (key) => key == ACTION_CHAR));
        }

        public override string Name => "Disconnected (Press 'c' to transition to Connected)";
    }
}
