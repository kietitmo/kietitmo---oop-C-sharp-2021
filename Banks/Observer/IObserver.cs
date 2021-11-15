using Banks.Models.Notification;

namespace Banks.Observer
{
    public interface IObserver
    {
        public void Notify(INotification notification);
    }
}
