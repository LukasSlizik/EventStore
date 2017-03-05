using Newtonsoft.Json;
using System;

namespace EventStore.Events
{
    public class ChangePasswordEvent : EventBase
    {
        public ChangePasswordEvent(string login, string newPassword)
        {
            NewPassword = newPassword;
            Login = login;
        }

        public override string EventName => "ChangePassword";
        public string Login { get; set; }

        public string NewPassword { get; set; }

        public override void PopulateFromJson(string json)
        {
            var o = JsonConvert.DeserializeObject<ChangePasswordEvent>(json);

            NewPassword = o.NewPassword;
        }
    }
}
