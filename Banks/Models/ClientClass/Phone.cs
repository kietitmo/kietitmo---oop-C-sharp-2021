using System.Collections.Generic;
using Banks.Models.Notification;

namespace Banks.Models.ClientClass
{
    public class Phone
    {
        public Phone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            Notifications = new List<INotification>();
        }

        public string PhoneNumber { get; set; }
        public List<INotification> Notifications { get; set; }
    }
}
