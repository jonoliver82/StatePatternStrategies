using Core.Interfaces;
using Core.Models;
using EventAggregatorPattern.Interfaces;
using EventAggregatorPattern.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorPattern.Factories
{
    public class StateFactory : IStateFactory
    {
        private readonly IEventAggregatorService _eventAggregatorService;
        private readonly ILogger _logger;

        public StateFactory(IEventAggregatorService eventAggregatorService,
            ILogger logger)
        {
            _eventAggregatorService = eventAggregatorService;
            _logger = logger;
        }

        public ITestStateBase Create(ConnectionState connectionState)
        {
            switch (connectionState)
            {
                case ConnectionState.Connected:
                    {
                        return new ConnectedState(_eventAggregatorService);
                    }
                case ConnectionState.Disconnected:
                    {
                        return new DisconnectedState(_eventAggregatorService);
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
