namespace EventStore.Events
{
    public class RegisterUserEvent : EventBase<RegisterUserEvent>
    {
        public RegisterUserEvent(string login, string userName, string password) : base(login)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}