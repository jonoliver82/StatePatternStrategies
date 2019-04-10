using CallbackStatePattern.Interfaces;
using Core.Interfaces;
using Core.Services;

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
