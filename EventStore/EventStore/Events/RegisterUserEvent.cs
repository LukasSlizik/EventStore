using Newtonsoft.Json;

namespace EventStore.Events
{
    public class RegisterUserEvent
    {
        public string Login { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static RegisterUserEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RegisterUserEvent>(json);
        }
    }
}