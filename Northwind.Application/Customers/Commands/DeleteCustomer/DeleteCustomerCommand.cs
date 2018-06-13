using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Northwind.Persistence;

namespace Northwind.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IDeleteCustomerCommand
    {
        private readonly NorthwindDbContext _context;

        public DeleteCustomerCommand(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task Execute(string id)
        {
            var entity = await _context.Customers.SingleAsync(c => c.CustomerId == id);

            _context.Customers.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
