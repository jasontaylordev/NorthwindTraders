using Dms.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Dms.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
