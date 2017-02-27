﻿using nblackbox.contract;
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
            var user = User.Restore(eventsForLogin);
            if (user != null && user.password == password)
                return true;

            return false;
        }

        public void ChangeName(string login, string password, string newName)
        {
            if (CanLogin(login, password))
                _blackBox.Record(new Event("ChangeName", login, newName));
        }

        public void ChangePassword(string login, string oldPassword, string newPassword)
        {
            if (CanLogin(login, oldPassword))
                _blackBox.Record(new Event("ChangePassword", login, newPassword));
        }

        public void Register(string login, string name, string password)
        {
            // ist der login eindeutig
            // ist das Passwort stark genug (nicht leer)
            // enthält Login nur gültige Zeichen
            _blackBox.Record("Register", login, $"{name},{password}");
        }
    }
}