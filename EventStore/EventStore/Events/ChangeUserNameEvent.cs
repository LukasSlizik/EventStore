using System;
using Newtonsoft.Json;

namespace EventStore.Events
{
    public class ChangeUserNameEvent : EventBase
    {
        public override string EventName => "ChangeUserName";

        public ChangeUserNameEvent(string login, string newUserName)
        {
            NewUserName = newUserName;
            Login = login;
        }

        public string NewUserName { get; set; }
        public string Login { get; set; }

        public override void PopulateFromJson(string json)
        {
            var o = JsonConvert.DeserializeObject<ChangeUserNameEvent>(json);
            NewUserName = o.NewUserName;
        }
    }
}
