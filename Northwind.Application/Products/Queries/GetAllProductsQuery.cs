using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Products.Models;
using Northwind.Persistence;

namespace Northwind.Application.Products.Queries
{
    public class GetAllProductsQuery : IGetAllProductsQuery
    {
        private readonly NorthwindDbContext _context;

        public GetAllProductsQuery(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> Execute()
        {
            return await _context.Products
                .Select(ProductDto.Projection)
                .OrderBy(p => p.ProductName)
                .ToListAsync();
        }
    }
}
