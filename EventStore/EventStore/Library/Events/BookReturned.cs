using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EventStore.Library.Events
{
    public class BookReturned : EventStore.Events.EventBase
    {
        public override string EventName => "BookReturned";

        public BookReturned(string bookTitle, string userName)
        {
            BookTitle = bookTitle;
            UserName = userName;
        }

        public string BookTitle { get; set; }
        public string UserName { get; set; }

        public override void PopulateFromJson(string json)
        {
            var o = JsonConvert.DeserializeObject<BookReturned>(json);

            BookTitle = o.BookTitle;
            UserName = o.UserName;
        }
    }
}
