using System;
using Banks.Models.Account;

namespace Banks.Models.BankTransactions
{
    public class Replenishing : IBankTransactions
    {
        private IAccount _acount;
        private double _sumAdding;
        public Replenishing(IAccount account, double sumAdding, DateTime date)
        {
            _acount = account;
            _sumAdding = sumAdding;
            Id = Guid.NewGuid();
            AccountOwnerId = account.Id;
            Date = date;
        }

        public Guid AccountOwnerId { get; set; }
        public Guid Id { get; }
        public DateTime Date { get; }
        public void DoOperation()
        {
            _acount.Balance += _sumAdding;
        }

        public void UndoOperation()
        {
            _acount.Balance -= _sumAdding;
        }
    }
}
