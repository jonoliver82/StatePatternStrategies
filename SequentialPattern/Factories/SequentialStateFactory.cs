using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using SequentialPattern.Interfaces;

namespace SequentialPattern.Factories
{
    public class SequentialStateFactory : IStateFactory, ISequentialStateFactory
    {
        private IEnumerable<ITestState> _testStates;
        private int _currentStateIndex = 0;

        public SequentialStateFactory(IEnumerable<ITestState> testStates)
        {
            _testStates = testStates.OrderBy(x => x.Order);
        }

        public ITestStateBase Create(ConnectionState connectionState)
        {
            return _testStates.Single(x => x.State == connectionState);
        }

        public ITestState CreateNext()
        {
            _currentStateIndex = (_currentStateIndex + 1) % _testStates.Count();
            return _testStates.ElementAt(_currentStateIndex);
        }
    }
}
