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

        public Book(){ }

        public Book(string bookName)
        {
            BookName = bookName;

            RegisterActions();
        }

        private void RegisterActions()
        {
            RegisterAction("BookCreated", (e, oldBook) =>
            {
                var data = JsonConvert.DeserializeObject<BookCreated>(e.Data);
                return new Book(data.Title);
            });

            RegisterAction("BookRemoved", (e, oldBook) =>
            {
                return null;
            });

            RegisterAction("BookLent", (e, oldBook) =>
            {
                var data = JsonConvert.DeserializeObject<BookLent>(e.Data);
                return new Book(data.BookTitle);
            });
        }
    }
}
