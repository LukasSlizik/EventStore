using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EventStore.Library.Events
{
    class BookRemoved : EventStore.Events.EventBase
    {
        public BookRemoved(string title) { }

        public override string EventName => "BookRemoved";
        public string Title { get; set; }

        public override void PopulateFromJson(string json)
        {
            var o = JsonConvert.DeserializeObject<BookRemoved>(json);
            Title = o.Title;
        }
    }
}
