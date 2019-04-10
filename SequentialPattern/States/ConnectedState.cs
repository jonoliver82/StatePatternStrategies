using SequentialPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequentialPattern.States
{
    public class ConnectedState : ITestState
    {
        public string Name => "Connected";

        public int Order => 2;

        public void HandleKeyPress(IConnectionService connectionService, char key)
        {
            connectionService.MoveToNextState();
        }
    }
}
