using nblackbox.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore
{
    class User
    {
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }

        public static User Restore(IEnumerable<IRecordedEvent> events)
        {
            User user = null;
            foreach (var @event in events)
            {
                if (@event.Name == "Register")
                    user = new User() { login = @event.Context,
                                        name = @event.Data.Split(',')[0],
                                        password = @event.Data.Split(',')[1]};

                if (@event.Name == "ChangeName")
                {
                    if (user == null) throw new InvalidOperationException("user not registered yet");
                    user.name = @event.Data;
                }

                if (@event.Name == "ChangePassword")
                {
                    if (user == null) throw new InvalidOperationException("user not registered yet");
                    user.password = @event.Data;
                }
            }

            return user;
        }
    }
}
