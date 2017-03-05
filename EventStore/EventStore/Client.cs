using EventStore.Login;
using nblackbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventStore.Library.Events;

namespace EventStore
{
    public class Client
    {
        public void Test()
        {
            // Login
            //var folderPath = "login";
            //var blackBox = new FolderBlackBox(folderPath);
            //var login = new UserLogin(blackBox);

            //login.Register("lukas.slizik", "Lukas", "123456");
            //login.Register("peter.black", "Peter", "p@ssword");

            //login.ChangePassword("lukas.slizik", "123456", "xyz");
            //login.ChangeName("lukas.slizik", "123456", "lslizik");

            // Library
            var folderPath = "library";
            var blackBox = new FolderBlackBox(folderPath);
            var mngr = new LibraryManager(blackBox);

            //mngr.CreateUser("Lukas");
            //mngr.CreateUser("Paul");
            //mngr.CreateUser("Thomas");
            //mngr.CreateBook("Harry Potter");
            //mngr.CreateBook("Herr der Ringe");
            mngr.LendBook("Game of Thrones", "Lukas");

        }
    }
}
