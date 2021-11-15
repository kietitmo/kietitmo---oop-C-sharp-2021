namespace Banks.Models.Notification
{
    public class PercentageChanged : INotification
    {
        public PercentageChanged()
        {
            ContentNotify = "Percentage is Changed";
        }

        public string ContentNotify { get; }
    }
}
