using System;
using System.Collections.Generic;
using Banks.Models.Account.AccountFactory;
using Banks.Models.ClientClass;
using Banks.Models.Notification;

namespace Banks.Models.Account
{
    public class CreditAcount : IAccount
    {
        public CreditAcount(DebtLimit linmit, Commission comission, double balance, Timer.TimeMachine timeMachine)
        {
            DebtLimit = linmit;
            Comission = comission;
            Balance = balance;
            Id = Guid.NewGuid();
            TypeAccount = AccountFactory.TypeAccount.Credit;
            Notification = new List<INotification>();
            LastDateUpdate = timeMachine.Date;
        }

        public DateTime LastDateUpdate { get; set; }
        public TypeAccount TypeAccount { get; set; }
        public Client Owner { get; set; }
        public double Balance { get; set; }
        public Guid Id { get; set; }
        public Guid IdBank { get; set; }
        public DebtLimit DebtLimit { get; set; }
        public Commission Comission { get; set; }
        public List<INotification> Notification { get; set; }
        public void CalculateBalanceWithComission()
        {
            if (Balance > 0)
            {
                return;
            }

            Balance -= Comission.ValueCommission;
        }

        public bool IsTransactionAvailable(double sum)
        {
            return (Balance - sum) > DebtLimit.ValueDebtLimit;
        }

        public void UpdateBalance(DateTime dateTime)
        {
            TimeSpan quantityDays = dateTime - LastDateUpdate;
            for (int i = 0; i < Math.Abs(quantityDays.TotalDays); i++)
            {
                CalculateBalanceWithComission();
            }

            LastDateUpdate = dateTime;
        }
    }
}
