using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nblackbox.contract;
using EventStore.Library.Entities;

namespace EventStore.Library.Events
{
    public class LibraryManager
    {
        private IBlackBox _blackBox;

        public LibraryManager(IBlackBox blackBox)
        {
            _blackBox = blackBox;
        }

        public void CreateBook(string title)
        {
            var e = new BookCreated(title);
            _blackBox.Record("BookCreated", title, e.ToJson());
        }

        public void RemoveBook(string title)
        {
            var e = new BookRemoved(title);
            _blackBox.Record("BookRemoved", title, e.ToJson());
        }

        public void CreateUser(string userName)
        {
            var e = new UserCreated(userName);
            _blackBox.Record("UserCreated", userName, e.ToJson());
        }

        public void RemoveUser(string userName)
        {
            var e = new UserRemoved(userName);
            _blackBox.Record("UserRemoved", userName, e.ToJson());
        }

        public void LendBook(string bookTitle, string userName)
        {
            if (!IsBookAvailable(bookTitle))
                return;

            var e = new BookLent(bookTitle, userName);
            _blackBox.Record("BookLent", bookTitle, e.ToJson());
        }

        private bool IsBookAvailable(string bookTitle)
        {
            var bookEvents = _blackBox.Player.WithContext(bookTitle).Play();
            var book = new Book().RestoreFromEvents(bookEvents);

            if (book == null || book.Status == BookStatus.Lent)
                return false;

            return true;
        }
    }
}
