using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EventStore.Library.Events
{
    public class UserCreated : EventStore.Events.EventBase
    {
        public UserCreated(string userName)
        {
            UserName = userName;
        }

        public override string EventName => "UserCreated";
        public string UserName { get; set; }

        public override void PopulateFromJson(string json)
        {
            var o = JsonConvert.DeserializeObject<UserCreated>(json);

            UserName = o.UserName;
        }
    }
}
