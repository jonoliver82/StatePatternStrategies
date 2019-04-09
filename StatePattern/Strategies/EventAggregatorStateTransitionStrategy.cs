using StatePattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatePattern.Events;
using StatePattern.Models;

namespace StatePattern.Strategies
{
    public class EventAggregatorStateTransitionStrategy : IStateTransitionStrategy
    {
        private readonly IEventAggregatorService _eventAggregatorService;

        // Not used in this strategy
        public event EventHandler<StateTransitionEventArgs> ChangeState;

        public EventAggregatorStateTransitionStrategy(IEventAggregatorService eventAggregatorService)
        {
            _eventAggregatorService = eventAggregatorService;
        }

        public string Name => "EventAggregator";

        public void MoveToState(IConnectionService connectionService, ConnectionState desiredState)
        {
            // Publish an event to the event aggregator. If the controller has subscribed to the aggregator it will be called.
            _eventAggregatorService.Publish<StateTransitionEventArgs>(new StateTransitionEventArgs(desiredState));
        }
    }
}
