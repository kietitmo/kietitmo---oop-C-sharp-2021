using System;
using Banks.ClientClass;

namespace Banks.Account
{
    public class DepositAcount : IAccount
    {
        private double _profit = 0;
        public DepositAcount(double persentage, double balance)
        {
            Persentage = persentage;
            Balance = balance;
            Id = Guid.NewGuid();
        }

        public Client Owner { get; set; }
        public double Balance { get; set; }
        public Guid Id { get; set; }
        public int IdBank { get; set; }
        public double Persentage { get; }
        public int Period { get; }
        public void CalculateBalanceWithPersentage()
        {
            _profit += (Balance * Persentage) / 100;
            Balance += _profit;
            _profit = 0;
        }

        public bool IsTransactionAvailable(double sum)
        {
            return (Balance > sum) && Period == 0;
        }
    }
}
