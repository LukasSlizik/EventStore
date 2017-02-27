using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore
{
    public interface IUserLogin
    {
        void Register(string login, string name, string password);
        bool CanLogin(string login, string password);
        void ChangePassword(string login, string oldPassword, string newPassword);
        void ChangeName(string login, string password, string newName);
    }
}
