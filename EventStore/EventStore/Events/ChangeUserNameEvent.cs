namespace EventStore.Events
{
    public class ChangeUserNameEvent : EventBase<ChangeUserNameEvent>
    {
        public ChangeUserNameEvent(string login, string newUserName) : base(login)
        {
            NewUserName = newUserName;
        }

        public string NewUserName { get; set; }
    }
}
