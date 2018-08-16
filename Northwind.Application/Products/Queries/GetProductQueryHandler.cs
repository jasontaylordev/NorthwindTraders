using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Exceptions;
using Northwind.Application.Products.Models;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Products.Queries
{
    public class GetProductQueryHandler : MediatR.IRequestHandler<GetProductQuery, ProductViewModel>
    {
        private readonly NorthwindDbContext _context;

        public GetProductQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<ProductViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Where(p => p.ProductId == request.Id)
                .Select(ProductDto.Projection)
                .SingleOrDefaultAsync(cancellationToken);

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            // TODO: Set view model state based on user permissions.
            var model = new ProductViewModel
            {
                Product = product,
                EditEnabled = true,
                DeleteEnabled = false
            };

            return model;
        }
    }
}
