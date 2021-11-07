using System;
using Banks.Account;

namespace Banks.BankTransactions
{
    public class WithDrawing : IBankTransactions
    {
        private IAccount _acount;
        private double _sum;

        public WithDrawing(IAccount acount, double sum)
        {
            _acount = acount;
            _sum = sum;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public void DoOperation()
        {
            _acount.Balance -= _sum;
        }

        public void UndoOperation()
        {
            _acount.Balance += _sum;
        }
    }
}
