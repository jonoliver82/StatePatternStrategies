using System;

namespace EventAggregatorPattern.Interfaces
{
    public interface IEventAggregatorService
    {
        void Publish<T>(T message)
            where T : EventArgs;

        void Subscribe<T>(Action<T> action)
            where T : EventArgs;
    }
}
