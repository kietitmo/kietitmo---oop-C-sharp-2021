using System;
using System.Collections.Generic;
using Banks.Exceptions;
using Banks.Models.Account;

namespace Banks.Repositories
{
    public class AccountRepository
    {
        public AccountRepository()
        {
            AccountList = new List<IAccount>();
        }

        public List<IAccount> AccountList { get; set; }
        public void AddAccount(IAccount account)
            => AccountList.Add(account);

        public IAccount GetAccountById(Guid id)
        {
            foreach (IAccount account in AccountList)
            {
                if (account.Id == id)
                {
                    return account;
                }
            }

            throw new BankException("AccountIsNotExistException");
        }

        public Guid GetId(Guid clientId, Guid bankId)
        {
            foreach (IAccount account in AccountList)
            {
                if (account.Owner.Id == clientId && account.IdBank == bankId)
                {
                    return account.Id;
                }
            }

            throw new BankException("AccountIsNotExistException");
        }

        public IEnumerable<IAccount> GetListKindOfAccount(Models.Account.AccountFactory.TypeAccount type)
        {
            var listAccount = new List<IAccount>();

            switch (type)
            {
                case Models.Account.AccountFactory.TypeAccount.Credit:
                    foreach (IAccount account in AccountList)
                    {
                        if (account.TypeAccount == Models.Account.AccountFactory.TypeAccount.Credit)
                        {
                            listAccount.Add(account);
                        }
                    }

                    break;

                case Models.Account.AccountFactory.TypeAccount.Deposit:
                    foreach (IAccount account in AccountList)
                    {
                        if (account.TypeAccount == Models.Account.AccountFactory.TypeAccount.Deposit)
                        {
                            listAccount.Add(account);
                        }
                    }

                    break;

                case Models.Account.AccountFactory.TypeAccount.Debit:
                    foreach (IAccount account in AccountList)
                    {
                        if (account.TypeAccount == Models.Account.AccountFactory.TypeAccount.Debit)
                        {
                            listAccount.Add(account);
                        }
                    }

                    break;
            }

            return listAccount;
        }

        public IEnumerable<IAccount> GetEnumerator()
            => AccountList;

        public int GetQuantityAccount()
        {
            return AccountList.Count;
        }
    }
}
