using Newtonsoft.Json;

namespace EventStore.Events
{
    public class ChangeUserNameEvent
    {
        public string Login {get;set;}
        public string NewUserName { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static ChangeUserNameEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ChangeUserNameEvent>(json);
        }
    }
}
