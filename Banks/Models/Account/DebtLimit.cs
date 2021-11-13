using Banks.Models.Notification;
using Banks.Observer;

namespace Banks.Models.Account
{
    public class DebtLimit : Subject
    {
        public DebtLimit(double valueDebtLimit)
        {
            ValueDebtLimit = valueDebtLimit;
        }

        public double ValueDebtLimit { get; set; }

        public void ChangeDebtLimit()
        {
            NotiifyObserver(new DebtLimitChanged());
        }
    }
}
