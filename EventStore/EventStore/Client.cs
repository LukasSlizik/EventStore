using nblackbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore
{
    public class Client
    {
        public void Test()
        {
            var folderPath = "login";
            var blackBox = new FolderBlackBox(folderPath);
            var login = new UserLogin(blackBox);

            login.Register("lukas.slizik", "Lukas", "123456");
            login.Register("peter.black", "Peter", "p@ssword");

            login.ChangePassword("lukas.slizik", "123456", "xyz");
            login.ChangeName("lukas.slizik", "123456", "lslizik");
        }
    }
}
