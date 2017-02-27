namespace EventStore.Events
{
    public class ChangePasswordEvent : EventBase<ChangePasswordEvent>
    {
        public ChangePasswordEvent(string login, string newPassword) : base(login)
        {
            NewPassword = newPassword;
        }

        public string NewPassword { get; set; }
    }
}
