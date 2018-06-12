using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Products.Models;
using Northwind.Domain;

namespace Northwind.Application.Products.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly NorthwindContext _context;

        public GetProductQueryHandler(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
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
                .SingleAsync(p => 
                    p.ProductId == request.ProductId, 
                    cancellationToken);
        }
    }
}
