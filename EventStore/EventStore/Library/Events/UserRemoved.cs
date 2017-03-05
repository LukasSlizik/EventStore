using Newtonsoft.Json;
using System;

namespace EventStore.Library.Events
{
    class UserRemoved : EventStore.Events.EventBase
    {
        public UserRemoved(string userName)
        {
            UserName = userName;
        }

        public override string EventName => "UserRemoved";
        public string UserName { get; set; }

        public override void PopulateFromJson(string json)
        {
            var o = JsonConvert.DeserializeObject<UserRemoved>(json);

            UserName = o.UserName;
        }
    }
}
