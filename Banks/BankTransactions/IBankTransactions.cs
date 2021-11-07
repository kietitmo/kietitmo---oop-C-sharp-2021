using System;
namespace Banks.BankTransactions
{
    public interface IBankTransactions
    {
        public Guid Id { get; }

        public void DoOperation();
        public void UndoOperation();
    }
}
