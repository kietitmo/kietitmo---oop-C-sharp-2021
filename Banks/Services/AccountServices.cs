using System;
using System.Collections.Generic;
using Banks.Models.Account;
using Banks.Models.Notification;
using Banks.Repositories;

namespace Banks.Services
{
    public class AccountServices
    {
        private readonly AccountRepository _accountRepository;
        public AccountServices(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void AddAccount(IAccount account)
           => _accountRepository.AddAccount(account);

        public IAccount GetAccountById(Guid id)
            => _accountRepository.GetAccountById(id);

        public IEnumerable<IAccount> GetEnumerator()
            => _accountRepository.GetEnumerator();

        public Guid GetId(Guid clientId, Guid bankId)
            => _accountRepository.GetId(clientId, bankId);

        public int GetQuantityAccount()
        {
            return _accountRepository.GetQuantityAccount();
        }

        public List<IAccount> GetListKindOfAccount(Models.Account.AccountFactory.TypeAccount type)
        {
            return _accountRepository.GetListKindOfAccount(type);
        }

        public void AddNotifications(IEnumerable<IAccount> accountList, INotification notification)
        {
            foreach (IAccount account in accountList)
            {
                account.Notification.Add(notification);
            }
        }

        public void AddNotificationForAccount(IAccount account, INotification notification)
        {
            account.Notification.Add(notification);
        }

        public void UpdateBalanceOfAllAccount(DateTime date)
        {
            foreach (IAccount account in _accountRepository.AccountList)
            {
                account.UpdateBalance(date);
            }
        }

        public List<INotification> GetNotificationOfAccount(IAccount account)
        {
            return account.Notification;
        }
    }
}
