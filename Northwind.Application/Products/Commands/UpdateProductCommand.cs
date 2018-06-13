using System.Threading.Tasks;
using Northwind.Application.Exceptions;
using Northwind.Application.Products.Models;
using Northwind.Domain;
using Northwind.Persistence;

namespace Northwind.Application.Products.Commands
{
    public class UpdateProductCommand : IUpdateProductCommand
    {
        private readonly NorthwindDbContext _context;

        public UpdateProductCommand(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Execute(ProductDto product)
        {
            var entity = await _context.Products
                .FindAsync(product.ProductId);

            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(Product), product.ProductId);
            }

            entity.ProductId = product.ProductId;
            entity.ProductName = product.ProductName;
            entity.CategoryId = product.CategoryId;
            entity.SupplierId = product.SupplierId;
            entity.UnitPrice = product.UnitPrice;
            entity.Discontinued = product.Discontinued;

            await _context.SaveChangesAsync();

            return ProductDto.Create(entity);
        }
    }
}
