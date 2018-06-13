using MediatR;
using Northwind.Application.Customers.Models;

namespace Northwind.Application.Customers.Queries
{
    public class GetCustomerDetailQuery : IRequest<CustomerDetailModel>
    {
        public string Id { get; set; }
    }
}
