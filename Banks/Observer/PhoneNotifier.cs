using System.Collections.Generic;
using Banks.Models.ClientClass;
using Banks.Models.Notification;

namespace Banks.Observer
{
    public class PhoneNotifier : IObserver
    {
        private List<Phone> _phoneList;
        public PhoneNotifier(List<Phone> phoneList)
        {
            _phoneList = phoneList;
        }

        public void Notify(INotification notification)
        {
            _phoneList.ForEach((phone) => phone.Notifications.Add(notification));
        }
    }
}
