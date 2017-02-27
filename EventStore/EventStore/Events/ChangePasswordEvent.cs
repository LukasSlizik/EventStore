using Newtonsoft.Json;

namespace EventStore.Events
{
    public class ChangePasswordEvent
    {
        public string Login { get; set; }
        public string NewPassword { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static ChangePasswordEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ChangePasswordEvent>(json);
        }
    }
}
