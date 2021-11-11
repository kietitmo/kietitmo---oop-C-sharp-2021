using System;
using System.Collections.Generic;
using Banks.Models.Account.AccountFactory;
using Banks.Models.ClientClass;
using Banks.Timer;

namespace Banks.Models.Account
{
    public class CreditAcount : IAccount
    {
        public CreditAcount(double linmit, double comission, double balance, Timer.TimeMachine timeMachine)
        {
            DebtLimit = linmit;
            Comission = comission;
            Balance = balance;
            Id = Guid.NewGuid();
            TypeAccount = AccountFactory.TypeAccount.Credit;
            Notification = new List<string>();
            LastDateUpdate = timeMachine.Date;
        }

        public DateTime LastDateUpdate { get; set; }
        public TypeAccount TypeAccount { get; set; }
        public Client Owner { get; set; }
        public double Balance { get; set; }
        public Guid Id { get; set; }
        public Guid IdBank { get; set; }
        public double DebtLimit { get; set; }
        public double Comission { get; set; }
        public List<string> Notification { get; set; }
        public void CalculateBalanceWithComission()
        {
            if (Balance > 0)
            {
                return;
            }

            Balance -= Comission;
        }

        public bool IsTransactionAvailable(double sum)
        {
            return (Balance - sum) > DebtLimit;
        }

        public void UpdateBalance(DateTime date)
        {
            TimeSpan quantityDays = date - LastDateUpdate;
            for (int i = 0; i < quantityDays.TotalDays; i++)
            {
                CalculateBalanceWithComission();
            }

            LastDateUpdate = date;
        }
    }
}
