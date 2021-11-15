using System.Collections.Generic;
using Banks.Models.Account;
using Banks.Models.Notification;

namespace Banks.Observer
{
    public class AccountNotifier : IObserver
    {
        private List<IAccount> _accountList;
        public AccountNotifier(List<IAccount> accountList)
        {
            _accountList = accountList;
        }

        public void Notify(INotification notification)
        {
            _accountList.ForEach((account) => account.Notification.Add(notification));
        }
    }
}
