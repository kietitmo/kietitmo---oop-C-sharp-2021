using System;
using System.Collections.Generic;
using Banks.Models.Account.AccountFactory;
using Banks.Models.ClientClass;
using Banks.Models.Notification;

namespace Banks.Models.Account
{
    public interface IAccount
    {
        public TypeAccount TypeAccount { get; set; }
        public Client Owner { get; set; }
        public double Balance { get; set; }
        public Guid Id { get; set; }
        public Guid IdBank { get; set; }
        public List<INotification> Notification { get; set; }
        public bool IsTransactionAvailable(double sum);
        public void UpdateBalance(DateTime date);
    }
}
