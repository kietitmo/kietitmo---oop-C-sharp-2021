namespace Banks.Models.Notification
{
    public class AnotherNotificotion : INotification
    {
        public AnotherNotificotion(string noty)
        {
            ContentNotify = noty;
        }

        public string ContentNotify { get; }
    }
}
