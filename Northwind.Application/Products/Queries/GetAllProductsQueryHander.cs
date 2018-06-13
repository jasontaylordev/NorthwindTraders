using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Products.Models;
using Northwind.Persistence;

namespace Northwind.Application.Products.Queries
{
    public class GetAllProductsQueryHander : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly NorthwindDbContext _context;

        public GetAllProductsQueryHander(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Select(ProductDto.Projection)
                .OrderBy(p => p.ProductName)
                .ToListAsync(cancellationToken);
        }
    }
}
