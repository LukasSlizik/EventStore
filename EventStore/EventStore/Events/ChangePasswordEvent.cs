using Newtonsoft.Json;
using System;

namespace EventStore.Events
{
    public class ChangePasswordEvent : EventBase
    {
        public ChangePasswordEvent(string login, string newPassword) : base(login)
        {
            NewPassword = newPassword;
        }

        public override string Name => "ChangePassword";

        public string NewPassword { get; set; }

        public override void PopulateFromJson(string json)
        {
            var o = JsonConvert.DeserializeObject<ChangePasswordEvent>(json);

            NewPassword = o.NewPassword;
        }
    }
}
