using Northwind.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Northwind.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
