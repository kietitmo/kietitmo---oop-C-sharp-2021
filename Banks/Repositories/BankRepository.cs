using System;
using System.Collections.Generic;
using Banks.Exceptions;
using Banks.Models.BankClass;

namespace Banks.Repositories
{
    public class BankRepository
    {
        public BankRepository()
        {
            BankList = new List<Bank>();
        }

        public List<Bank> BankList { get; set; }
        public Bank GetBankByName(string name)
        {
            foreach (Bank bank in BankList)
            {
                if (bank.Name == name)
                {
                    return bank;
                }
            }

            throw new BankException("BankIsNotExistException");
        }

        public Bank GetBankById(Guid id)
        {
            foreach (Bank bank in BankList)
            {
                if (bank.Id == id)
                {
                    return bank;
                }
            }

            throw new BankException("BankIsNotExistException");
        }

        public Guid GetBankIdByName(string name)
        {
            foreach (Bank bank in BankList)
            {
                if (bank.Name == name)
                {
                    return bank.Id;
                }
            }

            throw new BankException("BankIsNotExistException");
        }

        public IEnumerable<Bank> GetEnumerator()
            => BankList;

        public void AddBank(Bank bank)
        {
            BankList.Add(bank);
            return;
        }
    }
}
