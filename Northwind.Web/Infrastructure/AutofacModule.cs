using Autofac;
using Northwind.Application.Customers.Queries.GetCustomersList;
using Northwind.Common.Dates;

namespace Northwind.Web.Infrastructure
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(GetCustomersListQuery).Assembly)
                .Where(x => x.Name.EndsWith("Command") || x.Name.EndsWith("Query") || x.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterType<MachineDateTime>().As<IDateTime>();
        }
    }
}