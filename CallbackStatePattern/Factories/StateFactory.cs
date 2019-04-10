using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using CallbackStatePattern.States;

namespace CallbackStatePattern.Factories
{
    public class StateFactory : IStateFactory
    {
        private readonly ILogger _logger;

        public StateFactory(ILogger logger)
        {
            _logger = logger;
        }

        public ITestStateBase Create(ConnectionState connectionState)
        {
            switch (connectionState)
            {
                case ConnectionState.Connected:
                    {
                        return new ConnectedState();
                    }
                case ConnectionState.Disconnected:
                    {
                        return new DisconnectedState();
                    }
                default:
                    {
                        _logger.Log($"Unexpected ConnectionState: {connectionState}");
                        return null;
                    }
            }
        }
    }
}
