using Autofac;
using Northwind.Application.Customers.Queries.GetCustomersList;
using Northwind.Application.Interfaces;
using Northwind.Common;
using Northwind.Infrastructure;

namespace Northwind.WebUI.Infrastructure
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(GetCustomersListQueryHandler).Assembly)
                .Where(x => x.Name.EndsWith("Command") || x.Name.EndsWith("Query") || x.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterType<MachineDateTime>().As<IDateTime>();
            builder.RegisterType<NotificationService>().As<INotificationService>();
        }
    }
}