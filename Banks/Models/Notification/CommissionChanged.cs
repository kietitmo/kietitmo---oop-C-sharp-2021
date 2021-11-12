namespace Banks.Models.Notification
{
    public class CommissionChanged : INotification
    {
        public CommissionChanged()
        {
            ContentNotify = "Commission is changed";
        }

        public string ContentNotify { get; }
    }
}
