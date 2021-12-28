using System;
using System.Collections.Generic;
using Banks.Models.Account.AccountFactory;
using Banks.Models.ClientClass;
using Banks.Models.Notification;

namespace Banks.Models.Account
{
    public class DepositAcount : IAccount
    {
        private double _profit = 0;
        public DepositAcount(Persentage persentage, double balance, Timer.TimeMachine timeMachine)
        {
            Persentage = persentage;
            Balance = balance;
            Id = Guid.NewGuid();
            TypeAccount = AccountFactory.TypeAccount.Deposit;
            Notification = new List<INotification>();
            LastDateUpdate = timeMachine.Date;
        }

        public DateTime LastDateUpdate { get; set; }
        public TypeAccount TypeAccount { get; set; }
        public Client Owner { get; set; }
        public double Balance { get; set; }
        public Guid Id { get; set; }
        public Guid IdBank { get; set; }
        public Persentage Persentage { get; }
        public int Period { get; set; }
        public List<INotification> Notification { get; set; }
        public void CalculateBalanceWithPersentage()
        {
            if (Balance < Persentage.SumWithLowPersentage)
            {
                _profit += (Balance * Persentage.LowPersentage) / 100;
                Balance += _profit;
                _profit = 0;
            }

            if (Balance > Persentage.SumWithLowPersentage && Balance < Persentage.SumWithMediumPersentage)
            {
                _profit += (Balance * Persentage.MediumPersentage) / 100;
                Balance += _profit;
                _profit = 0;
            }

            if (Balance > Persentage.SumWithMediumPersentage)
            {
                _profit += (Balance * Persentage.HighPersentage) / 100;
                Balance += _profit;
                _profit = 0;
            }
        }

        public bool IsTransactionAvailable(double sum)
        {
            return (Balance > sum) && Period == 0;
        }

        public void UpdateBalance(DateTime dateTime)
        {
            TimeSpan quantityDays = dateTime - LastDateUpdate;
            for (int i = 0; i < Math.Abs(quantityDays.TotalDays); i++)
            {
                CalculateBalanceWithPersentage();
            }

            LastDateUpdate = dateTime;
        }
    }
}
