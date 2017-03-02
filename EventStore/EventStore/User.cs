using EventStore.Events;
using nblackbox.contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EventStore
{
    public class User
    {
        static Dictionary<string, Func<IRecordedEvent, User, User>> actions = new Dictionary<string, Func<IRecordedEvent, User, User>>();

        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        private void RegisterAction(string name, Func<IRecordedEvent, User, User> action)
        {
            actions.Add(name, action);
        }

        public User(string login, string name, string password)
        {
            Login = login;
            Password = password;
            Name = name;

            RegisterActions();
        }

        private void RegisterActions()
        {
            RegisterAction("RegisterUser", (e, oldUser) =>
            {
                var data = JsonConvert.DeserializeObject<RegisterUserEvent>(e.Data);
                return new User(data.Login, data.UserName, data.Password);
            });

            RegisterAction("ChangeUserName", (e, oldUser) =>
            {
                var data = JsonConvert.DeserializeObject<ChangeUserNameEvent>(e.Data);
                return new User(oldUser.Login, data.NewUserName, oldUser.Password);
            });

            RegisterAction("ChangePassword", (e, oldUser) =>
            {
                var data = JsonConvert.DeserializeObject<ChangePasswordEvent>(e.Data);
                return new User(oldUser.Login, oldUser.Name, data.NewPassword);
            });
        }

        public static User RestoreFromEvents(IEnumerable<IRecordedEvent> events)
        {
            User user = null;

            foreach (var @event in events)
            {
                var a = actions[@event.Name];
                user = a(@event, user);
            }

            return user;
        }
    }
}
