using Core.Interfaces;
using Core.Services;
using SequentialPattern.Interfaces;

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
