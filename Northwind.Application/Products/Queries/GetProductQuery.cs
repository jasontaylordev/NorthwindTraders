using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Exceptions;
using Northwind.Application.Products.Models;
using Northwind.Domain;
using Northwind.Persistence;

namespace Northwind.Application.Products.Queries
{
    public class GetProductQuery : IGetProductQuery
    {
        private readonly NorthwindDbContext _context;

        public GetProductQuery(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Execute(int id)
        {
            var product = await _context.Products
                .Where(p => p.ProductId == id)
                .Select(ProductDto.Projection)
                .SingleOrDefaultAsync();

            if (product == null)
            {
                throw new EntityNotFoundException(nameof(Product), id);
            }

            return product;
        }
    }
}
