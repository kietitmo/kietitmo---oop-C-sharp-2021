using System;
using Banks.Account;

namespace Banks.BankTransactions
{
    public class Transfering : IBankTransactions
    {
        private IAccount _fromAccount;
        private IAccount _toAccount;
        private double _sumTransfer;
        public Transfering(IAccount fromAccount, IAccount toAccount, double sumTransfer)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _sumTransfer = sumTransfer;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public void DoOperation()
        {
            _fromAccount.Balance -= _sumTransfer;
            _toAccount.Balance += _sumTransfer;
        }

        public void UndoOperation()
        {
            _fromAccount.Balance += _sumTransfer;
            _toAccount.Balance -= _sumTransfer;
        }
    }
}
