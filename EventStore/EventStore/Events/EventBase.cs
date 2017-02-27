using Newtonsoft.Json;

namespace EventStore.Events
{
    public class EventBase<T>
    {
        public EventBase(string login)
        {
            Login = login;
        }

        public string Login { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static T FromJson(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
