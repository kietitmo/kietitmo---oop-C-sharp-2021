using System;
using System.Collections.Generic;
using Banks.Models.BankClass;
using Banks.Repositories;

namespace Banks.Services
{
    public class BankServices
    {
        private readonly BankRepository _bankRepository;
        public BankServices(BankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public Bank GetBankByName(string name)
        {
            return _bankRepository.GetBankByName(name);
        }

        public Bank GetBankbyId(Guid id)
        {
            return _bankRepository.GetBankById(id);
        }

        public Guid GetBankIdbyName(string name)
        {
            return _bankRepository.GetBankIdByName(name);
        }

        public bool FindBankIdByName(string name)
        {
            return _bankRepository.FindBankIdByName(name);
        }

        public IEnumerable<Bank> GetEnumerator()
        {
            return _bankRepository.BankList;
        }

        public void AddBank(Bank bank)
        {
            _bankRepository.AddBank(bank);
            return;
        }
    }
}
