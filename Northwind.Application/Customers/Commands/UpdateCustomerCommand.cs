using MediatR;
using Northwind.Application.Customers.Models;

namespace Northwind.Application.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest<CustomerDetailModel>
    {
        public UpdateCustomerModel Customer { get; set; }
    }
}
