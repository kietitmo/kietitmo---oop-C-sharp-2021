using Banks.Models.Notification;
using Banks.Observer;

namespace Banks.Models.Account
{
    public class Commission : Subject
    {
        public Commission(double valueCommission)
        {
            ValueCommission = valueCommission;
        }

        public double ValueCommission { get; set; }

        public void ChangeCommission()
        {
            NotiifyObserver(new CommissionChanged());
        }
    }
}
