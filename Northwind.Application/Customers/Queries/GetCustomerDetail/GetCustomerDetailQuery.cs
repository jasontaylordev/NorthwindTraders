using MediatR;

namespace Northwind.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery : IRequest<CustomerDetailModel>
    {
        public string Id { get; set; }
    }
}
