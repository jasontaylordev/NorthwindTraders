using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Products.Models;
using Northwind.Domain;
using Northwind.Persistence;

namespace Northwind.Application.Products.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly NorthwindContext _context;

        public GetAllProductsQueryHandler(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    UnitPrice = p.UnitPrice,
                    CategoryName = p.Category.CategoryName,
                    SupplierCompanyName = p.Supplier.CompanyName,
                    Discontinued = p.Discontinued,
                })
                .Skip(request.PageIndex * request.PageSize)
                .Take(request.PageSize)
                .OrderBy(p => p.ProductName)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
