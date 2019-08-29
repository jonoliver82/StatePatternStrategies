using StateManagerPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using StateManagerPattern.Models;

namespace StateManagerPattern.States
{
    public abstract class BaseState : ITestState
    {
        private List<Rule> _rules;

        protected BaseState()
        {
            _rules = new List<Rule>();
        }

        public abstract string Name { get; }

        public List<Rule> Rules => _rules;

        public void AddTransitionRule(Rule rule)
        {
            _rules.Add(rule);
        }

        public virtual void HandleKeyPress(IConnectionServiceBase connectionService, char key)
        {
            // No action required in this pattern
        }

        public virtual void Update()
        {
            // No action required in base class
        }
    }
}
