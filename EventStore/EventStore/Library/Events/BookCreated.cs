using Newtonsoft.Json;

namespace EventStore.Library.Events
{
    class BookCreated : EventStore.Events.EventBase
    {
        public BookCreated(string title)
        {
            Title = title;
        }

        public string Title{ get; set; }
        public override string EventName => "BookCreated";

        public override void PopulateFromJson(string json)
        {
            var o = JsonConvert.DeserializeObject<BookCreated>(json);
            Title = o.Title;
        }
    }
}
