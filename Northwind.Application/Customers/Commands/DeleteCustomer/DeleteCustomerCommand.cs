using Microsoft.EntityFrameworkCore;
using Northwind.Persistence;
using System.Threading.Tasks;

namespace Northwind.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IDeleteCustomerCommand
    {
        public readonly NorthwindContext _context;

        public DeleteCustomerCommand(NorthwindContext context)
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
