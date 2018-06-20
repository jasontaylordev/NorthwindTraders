using Autofac;
using Northwind.Application.Customers.Queries;
using Northwind.Common;
using Northwind.Infrastructure;

namespace Northwind.WebApi.Infrastructure
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(GetCustomersListQueryHandler).Assembly)
                .Where(x => x.Name.EndsWith("Command") || x.Name.EndsWith("Query") || x.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterType<MachineDateTime>().As<IDateTime>();
        }
    }
}