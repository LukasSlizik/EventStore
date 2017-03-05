using EventStore.Events;
using Newtonsoft.Json;

namespace EventStore.Login
{
    public class User : RestorableObject<User>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public User() {}

        public User(string login, string name, string password)
        {
            Login = login;
            Password = password;
            Name = name;

            RegisterActions();
        }

        protected void RegisterActions()
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
    }
}
