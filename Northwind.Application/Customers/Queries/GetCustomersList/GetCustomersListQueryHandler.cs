using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Persistence;

namespace Northwind.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, CustomersListViewModel>
    {
        private readonly NorthwindDbContext _context;

        public GetCustomersListQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<CustomersListViewModel> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var vm = new CustomersListViewModel
            {
                Customers = await _context.Customers.Select(c =>
                    new CustomerLookupModel
                    {
                        Id = c.CustomerId,
                        Name = c.CompanyName
                    }).ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
