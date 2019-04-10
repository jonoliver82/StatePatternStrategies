using EventAggregatorPattern.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorPattern.Services
{
    public class EventAggregatorService : IEventAggregatorService
    {
        private readonly ConcurrentDictionary<Type, List<object>> _subscriptions;

        public EventAggregatorService()
        {
            _subscriptions = new ConcurrentDictionary<Type, List<object>>();
        }

        public void Publish<T>(T message) where T : EventArgs
        {
            List<object> subscribers;
            if (_subscriptions.TryGetValue(typeof(T), out subscribers))
            {
                // To Array creates a copy in case someone unsubscribes in their own handler
                foreach (var subscriber in subscribers.ToArray())
                {
                    ((Action<T>)subscriber)(message);
                }
            }
        }

        public void Subscribe<T>(Action<T> action) where T : EventArgs
        {
            var subscribers = _subscriptions.GetOrAdd(typeof(T), t => new List<object>());
            lock (subscribers)
            {
                subscribers.Add(action);
            }
        }
    }
}
