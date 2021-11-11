using System;
namespace Banks.Models.BankTransactions
{
    public interface IBankTransactions
    {
        public Guid Id { get; }

        public void DoOperation();
        public void UndoOperation();
    }
}
