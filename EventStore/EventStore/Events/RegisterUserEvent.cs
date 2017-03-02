using Newtonsoft.Json;
using System;

namespace EventStore.Events
{
    public class RegisterUserEvent : EventBase
    {
        public override string Name => "RegisterUser";

        public RegisterUserEvent(string login, string userName, string password) : base(login)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }

        public override void PopulateFromJson(string json)
        {
            var o = JsonConvert.DeserializeObject<RegisterUserEvent>(json);

            UserName = o.UserName;
            Password = o.Password;
        }
    }
}