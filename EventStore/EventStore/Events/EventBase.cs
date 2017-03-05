using Newtonsoft.Json;

namespace EventStore.Events
{
    public abstract class EventBase
    {
        public abstract string EventName { get; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public abstract void PopulateFromJson(string json);
    }
}
