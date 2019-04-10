using Core.Events;
using Core.Interfaces;
using Core.Models;
using EventAggregatorPattern.Interfaces;

namespace EventAggregatorPattern.States
{
    public class ConnectedState : ITestState
    {
        private readonly IEventAggregatorService _eventAggregatorService;

        public ConnectedState(IEventAggregatorService eventAggregatorService)
        {
            _eventAggregatorService = eventAggregatorService;
        }

        public string Name => "Connected";

        public void HandleKeyPress(IConnectionServiceBase connectionService, char key)
        {
            _eventAggregatorService.Publish<StateTransitionEventArgs>(new StateTransitionEventArgs(ConnectionState.Disconnected));
        }
    }
}
