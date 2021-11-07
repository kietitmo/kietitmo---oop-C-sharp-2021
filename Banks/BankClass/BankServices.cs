using System;
using System.Collections.Generic;
using System.Linq;

namespace Banks.BankClass
{
    public class BankServices
    {
        public BankServices()
        {
            BankList = new List<Bank>();
        }

        public List<Bank> BankList { get; set; }
        public Bank GetBankbyName(string name)
        {
            return BankList.Single(x => x.Name == name);
        }

        public Bank GetBankbyId(Guid id)
        {
            return BankList.Single(x => x.Id == id);
        }

        public Guid GetBankIdbyName(string name)
        {
            return BankList.Single(x => x.Name == name).Id;
        }

        public void AddBank(Bank bank)
        {
            BankList.Add(bank);
            return;
        }
    }
}
