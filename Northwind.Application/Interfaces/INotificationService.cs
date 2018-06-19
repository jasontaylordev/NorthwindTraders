using Northwind.Application.Notifications.Models;

namespace Northwind.Application.Interfaces
{
    public interface INotificationService
    {
        void Send(Message message);
    }
}
