using System;
using System.Collections.Generic;
using System.Linq;

namespace Banks.Account.AccountService
{
    public class AccountService
    {
        public AccountService()
        {
            AccountList = new List<IAccount>();
        }

        public List<IAccount> AccountList { get; set; }
        public void AddAccount(IAccount account)
            => AccountList.Add(account);

        public IAccount GetAccountById(Guid id)
            => AccountList.Single(x => x.Id == id);

        public IEnumerable<IAccount> GetEnumerator()
            => AccountList;

        public Guid GetId(Guid clientId, Guid bankId)
            => AccountList.Single(x =>
                x.Id == clientId && x.Id == bankId).Id;
    }
}
