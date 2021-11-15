using System.Collections.Generic;
using Banks.Models.Notification;

namespace Banks.Observer
{
    public class Subject
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void DeleteObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotiifyObserver(INotification notification)
        {
            _observers.ForEach((observer) => observer.Notify(notification));
        }
    }
}
