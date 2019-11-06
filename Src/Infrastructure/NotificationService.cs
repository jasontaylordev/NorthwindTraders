using Dms.Application.Common.Interfaces;
using Dms.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Dms.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
