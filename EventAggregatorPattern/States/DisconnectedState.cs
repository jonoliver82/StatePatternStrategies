using Core.Events;
using Core.Interfaces;
using Core.Models;
using EventAggregatorPattern.Interfaces;

namespace EventAggregatorPattern.States
{
    public class DisconnectedState : ITestState
    {
        private readonly IEventAggregatorService _eventAggregatorService;

        public DisconnectedState(IEventAggregatorService eventAggregatorService)
        {
            _eventAggregatorService = eventAggregatorService;
        }

        public string Name => "Disconnected";

        public void HandleKeyPress(IConnectionServiceBase connectionService, char key)
        {
            _eventAggregatorService.Publish<StateTransitionEventArgs>(new StateTransitionEventArgs(ConnectionState.Connected));
        }
    }
}
