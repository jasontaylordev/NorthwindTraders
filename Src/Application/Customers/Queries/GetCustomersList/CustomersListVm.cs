using System.Collections.Generic;

namespace Northwind.Application.Customers.Queries.GetCustomersList
{
    public class CustomersListVm
    {
        public IList<CustomerLookup> Customers { get; set; }
    }
}
