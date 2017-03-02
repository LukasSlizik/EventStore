using Newtonsoft.Json;

namespace EventStore.Events
{
    public abstract class EventBase
    {
        public abstract string Name { get; }

        public EventBase(string login)
        {
            Login = login;
        }

        public string Login { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public abstract void PopulateFromJson(string json);
    }
}
