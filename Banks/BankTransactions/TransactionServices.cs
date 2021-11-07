using System;
using System.Collections.Generic;
using System.Linq;

namespace Banks.BankTransactions
{
    public class TransactionServices
    {
        public TransactionServices()
        {
            TransactionList = new List<IBankTransactions>();
        }

        public List<IBankTransactions> TransactionList { get; set; }

        public void AddTrans(IBankTransactions transaction)
           => TransactionList.Add(transaction);

        public IEnumerable<IBankTransactions> GetEnumerator()
            => TransactionList;

        public IBankTransactions GetTransactions(Guid id)
            => TransactionList.Single(x => x.Id == id);

        public void RemoveTransactions(IBankTransactions transaction)
        {
            TransactionList.Remove(transaction);
        }

        public void Update(List<IBankTransactions> newList)
            => TransactionList = newList;
    }
}
