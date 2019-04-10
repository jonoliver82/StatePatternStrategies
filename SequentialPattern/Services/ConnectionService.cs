using Core.Interfaces;
using Core.Models;
using SequentialPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequentialPattern.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly ILogger _logger;
        private IEnumerable<ITestState> _testStates;
        private bool _continue;
        private ITestState _currentState;
        private int _currentStateIndex = 0;

        public ConnectionService(ILogger logger, IEnumerable<ITestState> testStates)
        {
            _logger = logger;
            _testStates = testStates.OrderBy(x => x.Order);
            _currentState = _testStates.First();
            _continue = true;

            LogCurrentState();
        }

        public bool Continue => _continue;

        public void HandleKeyPress(char key)
        {
            _currentState.HandleKeyPress(this, key);
            LogCurrentState();
        }

        public void MoveToNextState()
        {
            _currentStateIndex = (_currentStateIndex + 1) % _testStates.Count();
            _currentState = _testStates.ElementAt(_currentStateIndex);
        }

        private void LogCurrentState()
        {
            _logger.Log("\nCurrent State: " + _currentState.Name);
        }
    }
}
