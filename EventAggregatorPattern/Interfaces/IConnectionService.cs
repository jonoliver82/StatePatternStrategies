using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorPattern.Interfaces
{
    public interface IConnectionService
    {
        bool Continue { get; }

        void HandleKeyPress(char key);
    }
}
