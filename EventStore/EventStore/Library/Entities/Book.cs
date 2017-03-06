using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EventStore.Library.Events;

namespace EventStore.Library.Entities
{
    public class Book : RestorableObject<Book>
    {
        string BookName { get; set; }

        public Book()
        {
            RegisterActions();
        }

        public Book(string bookName, BookStatus status) : this()
        {
            BookName = bookName;
            Status = status;
        }

        public BookStatus Status { get; set; }

        private void RegisterActions()
        {
            RegisterAction("BookCreated", (e, oldBook) =>
            {
                var data = JsonConvert.DeserializeObject<BookCreated>(e.Data);
                return new Book(data.Title, BookStatus.Home);
            });

            RegisterAction("BookRemoved", (e, oldBook) =>
            {
                return null;
            });

            RegisterAction("BookLent", (e, oldBook) =>
            {
                var data = JsonConvert.DeserializeObject<BookLent>(e.Data);
                return new Book(data.BookTitle, BookStatus.Lent);

            });

            RegisterAction("BookReturned", (e, oldBook) =>
            {
                var data = JsonConvert.DeserializeObject<BookReturned>(e.Data);
                return new Book(data.BookTitle, BookStatus.Home);
            });
        }
    }

    public enum BookStatus
    {
        Home,
        Lent
    }
}
