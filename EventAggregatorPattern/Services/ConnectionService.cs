using Core.Events;
using Core.Interfaces;
using Core.Models;
using Core.Services;
using EventAggregatorPattern.Interfaces;
using EventAggregatorPattern.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorPattern.Services
{
    public class ConnectionService : ConnectionServiceBase, IConnectionService
    {
        private readonly IEventAggregatorService _eventAggregatorService;

        public ConnectionService(IStateFactory stateFactory, 
            ILogger logger, 
            IEventAggregatorService eventAggregatorService)
            : base(stateFactory, logger)
        {
            _eventAggregatorService = eventAggregatorService;

            // Subscribe to the event aggregator for state transition events
            _eventAggregatorService.Subscribe<StateTransitionEventArgs>(OnStateTransitionRequest);
        }

        private void OnStateTransitionRequest(StateTransitionEventArgs e)
        {
            MoveToState(e.DesiredState);
        }
    }
}
