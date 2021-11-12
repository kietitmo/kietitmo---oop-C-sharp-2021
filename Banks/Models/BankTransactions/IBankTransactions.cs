using System;

namespace Banks.Models.BankTransactions
{
    public interface IBankTransactions
    {
        public Guid Id { get; }
        public Guid AccountOwnerId { get; set; }
        public DateTime Date { get; }
        public void DoOperation();
        public void UndoOperation();
    }
}
