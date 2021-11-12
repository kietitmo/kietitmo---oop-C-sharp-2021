namespace Banks.Models.Notification
{
    public class ReducedBalance : INotification
    {
        public ReducedBalance()
        {
            ContentNotify = "Account reduced money!";
        }

        public string ContentNotify { get; }
    }
}
