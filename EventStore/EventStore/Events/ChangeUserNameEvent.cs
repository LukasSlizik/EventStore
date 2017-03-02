using System;
using Newtonsoft.Json;

namespace EventStore.Events
{
    public class ChangeUserNameEvent : EventBase
    {
        public override string Name => "ChangeUserName";

        public ChangeUserNameEvent(string login, string newUserName) : base(login)
        {
            NewUserName = newUserName;
        }

        public string NewUserName { get; set; }

        public override void PopulateFromJson(string json)
        {
            var o = JsonConvert.DeserializeObject<ChangeUserNameEvent>(json);
            NewUserName = o.NewUserName;
        }
    }
}
