using nblackbox.contract;
using System;
using System.Collections.Generic;

namespace EventStore
{
    public abstract class RestorableObject<T> where T : new()
    {
        private Dictionary<string, Func<IRecordedEvent, T, T>> actions = new Dictionary<string, Func<IRecordedEvent, T, T>>();
        protected void RegisterAction(string name, Func<IRecordedEvent, T, T> action)
        {
            actions.Add(name, action);
        }

        public T RestoreFromEvents(IEnumerable<IRecordedEvent> events)
        {
            T obj = default(T);

            foreach (var @event in events)
            {
                var a = actions[@event.Name];
                obj = a(@event, obj);
            }

            return obj;
        }
    }
}
