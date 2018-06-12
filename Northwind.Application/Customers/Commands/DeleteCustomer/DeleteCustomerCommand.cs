using Microsoft.EntityFrameworkCore;
using Northwind.Domain;
using System.Threading.Tasks;
using Northwind.Persistence;

namespace Northwind.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IDeleteCustomerCommand
    {
        private readonly NorthwindContext _context;

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
