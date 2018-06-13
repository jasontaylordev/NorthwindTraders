using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Northwind.Persistence;

namespace Northwind.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery : IGetCustomerDetailQuery
    {
        private readonly NorthwindDbContext _context;

        public GetCustomerDetailQuery(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerDetailModel> Execute(string id)
        {
            var entity = await _context.Customers.SingleAsync(c => c.CustomerId == id);

            return new CustomerDetailModel
            {
                Id = entity.CustomerId,
                Address = entity.Address,
                City = entity.City,
                CompanyName = entity.CompanyName,
                ContactName = entity.ContactName,
                ContactTitle = entity.ContactTitle,
                Country = entity.Country,
                Fax = entity.Fax,
                Phone = entity.Phone,
                PostalCode = entity.PostalCode,
                Region = entity.Region
            };
        }
    }
}
