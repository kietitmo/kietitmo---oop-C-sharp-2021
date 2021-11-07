using System;
using Banks.ClientClass;

namespace Banks.Account
{
    public class CreditAcount : IAccount
    {
        private double _sumOfCommission = 0;
        public CreditAcount(double linmit, double comission, double balance)
        {
            DebtLimit = linmit;
            Comission = comission;
            Balance = balance;
            Id = Guid.NewGuid();
        }

        public Client Owner { get; set; }
        public double Balance { get; set; }
        public Guid Id { get; set; }
        public int IdBank { get; set; }
        public double DebtLimit { get; set; }
        public double Comission { get; set; }
        public void CalculateBalanceWithComission()
        {
            _sumOfCommission += (Balance * Comission) / 100;
            Balance -= _sumOfCommission;
        }

        public bool IsTransactionAvailable(double sum)
        {
            return (Balance - sum) > DebtLimit;
        }
    }
}
