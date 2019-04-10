using SequentialPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequentialPattern.States
{
    public class DisconnectedState : ITestState
    {
        public string Name => "Disconnected";

        public int Order => 1;

        public void HandleKeyPress(IConnectionService connectionService, char key)
        {
            connectionService.MoveToNextState();
        }
    }
}
