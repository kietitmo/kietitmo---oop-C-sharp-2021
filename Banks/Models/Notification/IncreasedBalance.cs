namespace Banks.Models.Notification
{
    public class IncreasedBalance : INotification
    {
        public IncreasedBalance()
        {
            ContentNotify = "Account receives money!";
        }

        public string ContentNotify { get; }
    }
}
