using EventStore.Events;
using nblackbox.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore
{
    public class UserLogin : IUserLogin
    {
        private IBlackBox _blackBox;

        public UserLogin(IBlackBox blackBox)
        {
            _blackBox = blackBox;
        }

        public bool CanLogin(string login, string password)
        {
            var eventsForLogin = _blackBox.Player.WithContext(login).Play();
            var user = User.RestoreFromEvents(eventsForLogin);
            if (user != null && user.Password == password)
                return true;

            return false;
        }

        public void ChangeName(string login, string password, string newName)
        {
            if (CanLogin(login, password))
            {
                var e = new ChangeUserNameEvent(login, newName);
                _blackBox.Record(new Event("ChangeName", login, e.ToJson()));
            }
        }

        public void ChangePassword(string login, string oldPassword, string newPassword)
        {
            if (CanLogin(login, oldPassword))
            {
                var e = new ChangePasswordEvent(login, newPassword);
                _blackBox.Record(new Event("ChangePassword", login, e.ToJson()));
            }
        }

        public void Register(string login, string name, string password)
        {
            var e = new RegisterUserEvent(login, name, password);
            _blackBox.Record("RegisterUser", login, e.ToJson());
        }
    }
}
