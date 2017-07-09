using Autofac;
using NorthwindTraders.Application.Customers.Commands.CreateCustomer;
using NorthwindTraders.Application.Customers.Commands.DeleteCustomer;
using NorthwindTraders.Application.Customers.Commands.UpdateCustomer;
using NorthwindTraders.Application.Customers.Queries.GetCustomerDetail;
using NorthwindTraders.Application.Customers.Queries.GetCustomersList;
using NorthwindTraders.Common.Dates;

namespace NorthwindTraders.Infrastructure
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetCustomersListQuery>().As<IGetCustomersListQuery>();
            builder.RegisterType<GetCustomerDetailQuery>().As<IGetCustomerDetailQuery>();
            builder.RegisterType<CreateCustomerCommand>().As<ICreateCustomerCommand>();
            builder.RegisterType<UpdateCustomerCommand>().As<IUpdateCustomerCommand>();
            builder.RegisterType<DeleteCustomerCommand>().As<IDeleteCustomerCommand>();
            builder.RegisterType<MachineDateTime>().As<IDateTime>();
        }
    }
}
