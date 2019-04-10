using CallbackStatePattern.Interfaces;
using CallbackStatePattern.States;
using Core.Interfaces;
using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackStatePattern.Services
{
    public class ConnectionService : ConnectionServiceBase, IConnectionService
    {
        public ConnectionService(IStateFactory stateFactory, ILogger logger)
            : base(stateFactory, logger)
        {
        }
    }
}
