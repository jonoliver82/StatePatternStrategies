using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Interfaces
{
    public interface IEventAggregatorService
    {
        void Publish<T>(T message)
            where T : EventArgs;

        void Subscribe<T>(Action<T> action)
            where T : EventArgs;
    }
}
