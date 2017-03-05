using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EventStore.Library.Events
{
    public class BookLent : EventStore.Events.EventBase
    {
        public BookLent(string bookTitle, string userName)
        {
            BookTitle = bookTitle;
            UserName = userName;
        }

        public override string EventName => "BookLent";
        public string BookTitle { get; set; }
        public string UserName { get; set; }

        public override void PopulateFromJson(string json)
        {
            var o = JsonConvert.DeserializeObject<BookLent>(json);

            BookTitle = o.BookTitle;
            UserName = o.UserName;
        }
    }
}
