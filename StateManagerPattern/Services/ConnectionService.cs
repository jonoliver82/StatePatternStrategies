using Core.Interfaces;
using Core.Services;
using StateManagerPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagerPattern.Services
{
    public class ConnectionService : ConnectionServiceBase, IConnectionService
    {
        public ConnectionService(IStateFactory stateFactory, ILogger logger)
            : base(stateFactory, logger)
        {
            LogCurrentState();
        }

        public override void HandleKeyPress(char key)
        {
            // Test each transition rule for the current state
            foreach (var rule in ((ITestState)_currentState).Rules)
            {
                // Execute the function, if it returns true then we need to perform the transition
                if (rule.Func(key))
                {
                    // Transition to the destination state
                    MoveToState(rule.DestinationState);
                    LogCurrentState();
                    break;
                }
            }
        }
    }
}
