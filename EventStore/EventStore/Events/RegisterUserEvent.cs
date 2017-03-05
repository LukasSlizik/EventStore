using Newtonsoft.Json;
using System;

namespace EventStore.Events
{
    public class RegisterUserEvent : EventBase
    {
        public override string EventName => "RegisterUser";

        public RegisterUserEvent(string login, string userName, string password)
        {
            UserName = userName;
            Password = password;
            Login = login;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        public override void PopulateFromJson(string json)
        {
            var o = JsonConvert.DeserializeObject<RegisterUserEvent>(json);

            UserName = o.UserName;
            Password = o.Password;
        }
    }
}