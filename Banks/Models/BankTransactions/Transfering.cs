using System;
using Banks.Models.Account;

namespace Banks.Models.BankTransactions
{
    public class Transfering : IBankTransactions
    {
        private IAccount _fromAccount;
        private IAccount _toAccount;
        private double _sumTransfer;
        public Transfering(IAccount fromAccount, IAccount toAccount, double sumTransfer, DateTime date)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _sumTransfer = sumTransfer;
            Id = Guid.NewGuid();
            AccountOwnerId = fromAccount.Id;
            TargetAccountOwnerID = toAccount.Id;
            Date = date;
        }

        public Guid AccountOwnerId { get; set; }
        public Guid TargetAccountOwnerID { get; set; }
        public Guid Id { get; }
        public DateTime Date { get; }

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
