using System.Threading.Tasks;
using Northwind.Application.Exceptions;
using Northwind.Domain;
using Northwind.Persistence;

namespace Northwind.Application.Products.Commands
{
    public class DeleteProductCommand : IDeleteProductCommand
    {
        private readonly NorthwindDbContext _context;

        public DeleteProductCommand(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task Execute(int id)
        {
            var entity = await _context.Products.FindAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(Product), id);
            }

            _context.Products.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
