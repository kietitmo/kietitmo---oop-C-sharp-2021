using System;
using System.Collections.Generic;
using System.Linq;
using Banks.Exceptions;
using Banks.Models.BankTransactions;

namespace Banks.Repositories
{
    public class TransactionRepository
    {
        public TransactionRepository()
        {
            TransactionList = new List<IBankTransactions>();
        }

        public List<IBankTransactions> TransactionList { get; set; }

        public void AddTransaction(IBankTransactions transaction)
           => TransactionList.Add(transaction);

        public IEnumerable<IBankTransactions> GetEnumerator()
            => TransactionList;

        public IBankTransactions GetTransactions(Guid id)
        {
            foreach (IBankTransactions transaction in TransactionList)
            {
                if (transaction.Id == id)
                {
                    return transaction;
                }
            }

            throw new BankException("TransactionIsNotExistException");
        }

        public void RemoveTransactions(IBankTransactions transaction)
        {
            TransactionList.Remove(transaction);
        }

        public void Update(List<IBankTransactions> newList)
            => TransactionList = newList;

        public IEnumerable<IBankTransactions> GetAllTransactionOfAccount(Guid accountId)
        {
            var transactionsList = new List<IBankTransactions>();
            foreach (IBankTransactions transaction in TransactionList)
            {
                if (transaction.AccountOwnerId == accountId)
                {
                    transactionsList.Add(transaction);
                }
            }

            return transactionsList;
        }

        public IBankTransactions GetLastTransactionOfAccount(Guid accountID)
        {
            return GetAllTransactionOfAccount(accountID).Last();
        }
    }
}
