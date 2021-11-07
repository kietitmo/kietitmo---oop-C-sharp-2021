using System;
using Banks.ClientClass;

namespace Banks.Account
{
    public class DebitAcount : IAccount
    {
        private double _profit = 0;
        public DebitAcount(double persentage, double balance)
        {
            Balance = balance;
            Persentage = persentage;
            Id = Guid.NewGuid();
        }

        public Client Owner { get; set; }
        public double Balance { get; set; }
        public Guid Id { get; set; }
        public int IdBank { get; set; }
        public double Persentage { get; }
        public void CalculateBalanceWithPersentage()
        {
            _profit += (Balance * Persentage) / 100;
            Balance += _profit;
            _profit = 0;
        }

        public bool IsTransactionAvailable(double sum)
        {
            return Balance > sum;
        }
    }
}
