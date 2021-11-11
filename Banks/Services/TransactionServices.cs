using System;
using System.Collections.Generic;
using Banks.Models.BankTransactions;
using Banks.Repositories;

namespace Banks.Services
{
    public class TransactionServices
    {
        private readonly TransactionRepository _transactionRepository;
        public TransactionServices(TransactionRepository transactionServices)
        {
            _transactionRepository = transactionServices;
        }

        public void AddTransaction(IBankTransactions transaction)
          => _transactionRepository.AddTransaction(transaction);

        public IEnumerable<IBankTransactions> GetEnumerator()
            => _transactionRepository.GetEnumerator();

        public IBankTransactions GetTransactions(Guid id)
            => _transactionRepository.GetTransactions(id);

        public void RemoveTransactions(IBankTransactions transaction)
        {
            _transactionRepository.RemoveTransactions(transaction);
        }

        public void Update(List<IBankTransactions> newList)
            => _transactionRepository.TransactionList = newList;
    }
}
