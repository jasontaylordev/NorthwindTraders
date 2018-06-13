using MediatR;

namespace Northwind.Application.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest
    {
        public string Id { get; set; }
    }
}
