using System.Collections.Generic;
using MediatR;
using Northwind.Application.Customers.Models;

namespace Northwind.Application.Customers.Queries
{
    public class GetCustomerListQuery : IRequest<List<CustomerListModel>>
    {
    }
}
