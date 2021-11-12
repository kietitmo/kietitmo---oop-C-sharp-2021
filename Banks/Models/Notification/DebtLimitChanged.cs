namespace Banks.Models.Notification
{
    public class DebtLimitChanged : INotification
    {
        public DebtLimitChanged()
        {
            ContentNotify = "Debt Limit is Changed";
        }

        public string ContentNotify { get; }
    }
}
