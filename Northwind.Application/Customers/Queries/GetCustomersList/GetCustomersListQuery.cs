using Microsoft.EntityFrameworkCore;
using Northwind.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IGetCustomersListQuery
    {
        public readonly NorthwindContext _context;

        public GetCustomersListQuery(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerListModel>> Execute()
        {
            return await _context.Customers.Select(c =>
                new CustomerListModel
                {
                    Id = c.CustomerId,
                    Name = c.CompanyName
                }).ToListAsync();
        }
    }
}
