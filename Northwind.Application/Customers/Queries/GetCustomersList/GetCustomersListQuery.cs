using Microsoft.EntityFrameworkCore;
using Northwind.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Persistence;

namespace Northwind.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IGetCustomersListQuery
    {
        private readonly NorthwindContext _context;

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
