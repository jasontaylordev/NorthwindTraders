using System.Threading.Tasks;
using Northwind.Application.Products.Models;
using Northwind.Domain;
using Northwind.Persistence;

namespace Northwind.Application.Products.Commands
{
    public class CreateProductCommand : ICreateProductCommand
    {
        private readonly NorthwindDbContext _context;

        public CreateProductCommand(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Execute(ProductDto product)
        {
            var entity = new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,
                UnitPrice = product.UnitPrice,
                Discontinued = product.Discontinued
            };

            _context.Products.Add(entity);

            await _context.SaveChangesAsync();

            return ProductDto.Create(entity);
        }
    }
}
