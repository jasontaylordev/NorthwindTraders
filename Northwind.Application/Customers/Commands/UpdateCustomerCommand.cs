using MediatR;
using Northwind.Application.Customers.Models;

namespace Northwind.Application.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest<CustomerDetailModel>
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Country { get; set; }
        public string Fax { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
    }
}
