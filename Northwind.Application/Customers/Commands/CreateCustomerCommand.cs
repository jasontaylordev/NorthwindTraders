using MediatR;
using Northwind.Application.Customers.Models;

namespace Northwind.Application.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<CustomerDetailModel>
    {
        public CreateCustomerModel Customer { get; set; }        
    }
}
