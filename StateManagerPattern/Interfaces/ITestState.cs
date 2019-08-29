using Core.Interfaces;
using Core.Models;
using StateManagerPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagerPattern.Interfaces
{
    public interface ITestState : ITestStateBase
    {
        List<Rule> Rules { get; }

        void AddTransitionRule(Rule rule);

        void Update();
    }
}
