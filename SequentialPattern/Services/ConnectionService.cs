using Core.Interfaces;
using Core.Models;
using Core.Services;
using SequentialPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequentialPattern.Services
{
    public class ConnectionService : ConnectionServiceBase, IConnectionService
    {
        public ConnectionService(ISequentialStateFactory stateFactory, 
            ILogger logger)
            : base((IStateFactory)stateFactory, logger)
        {
        }

        public void MoveToNextState()
        {
            _currentState = ((ISequentialStateFactory)StateFactory).CreateNext();
        }
    }
}
