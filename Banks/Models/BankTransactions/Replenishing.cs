using System;
using Banks.Models.Account;

namespace Banks.Models.BankTransactions
{
    public class Replenishing : IBankTransactions
    {
        private IAccount _acount;
        private double _sumAdding;
        public Replenishing(IAccount acount, double sumAdding)
        {
            _acount = acount;
            _sumAdding = sumAdding;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
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
