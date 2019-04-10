using Core.Interfaces;
using Core.Models;
using RaiseEventPattern.States;

namespace RaiseEventPattern.Factories
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
