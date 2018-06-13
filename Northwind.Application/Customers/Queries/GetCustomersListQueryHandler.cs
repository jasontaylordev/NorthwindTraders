using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Customers.Models;
using Northwind.Persistence;

namespace Northwind.Application.Customers.Queries
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomerListQuery, IEnumerable<CustomerListModel>>
    {
        private readonly NorthwindDbContext _context;

        public GetCustomersListQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerListModel>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Customers.Select(c =>
                new CustomerListModel
                {
                    Id = c.CustomerId,
                    Name = c.CompanyName
                }).ToListAsync(cancellationToken);
        }
    }
}
