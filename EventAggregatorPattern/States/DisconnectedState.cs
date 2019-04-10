using Core.Events;
using Core.Models;
using EventAggregatorPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void HandleKeyPress(char key)
        {
            _eventAggregatorService.Publish<StateTransitionEventArgs>(new StateTransitionEventArgs(ConnectionState.Connected));
        }
    }
}
