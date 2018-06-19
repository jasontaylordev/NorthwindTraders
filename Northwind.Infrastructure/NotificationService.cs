using System;
using Northwind.Application.Interfaces;
using Northwind.Application.Notifications.Models;

namespace Northwind.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public void Send(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
