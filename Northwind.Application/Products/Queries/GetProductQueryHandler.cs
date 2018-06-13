using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Exceptions;
using Northwind.Application.Products.Models;
using Northwind.Domain;
using Northwind.Persistence;

namespace Northwind.Application.Products.Queries
{
    public class GetProductQueryHandler : MediatR.IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly NorthwindDbContext _context;

        public GetProductQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Where(p => p.ProductId == request.Id)
                .Select(ProductDto.Projection)
                .SingleOrDefaultAsync(cancellationToken);

            if (product == null)
            {
                throw new EntityNotFoundException(nameof(Product), request.Id);
            }

            return product;
        }
    }
}
