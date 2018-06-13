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
    public class GetAllProductsQueryHander : IRequestHandler<GetAllProductsQuery, ProductsListViewModel>
    {
        private readonly NorthwindDbContext _context;

        public GetAllProductsQueryHander(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<ProductsListViewModel> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            // TODO: Set view model state based on user permissions.
            var model = new ProductsListViewModel
            {
                Products = await _context.Products
                    .Select(ProductDto.Projection)
                    .OrderBy(p => p.ProductName)
                    .ToListAsync(cancellationToken),
                CreateEnabled = true
            };

            return model;
        }
    }
}
