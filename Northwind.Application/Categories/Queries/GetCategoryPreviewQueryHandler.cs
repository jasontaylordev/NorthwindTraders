using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Categories.Models;
using Northwind.Application.Interfaces;

namespace Northwind.Application.Categories.Queries
{
    public class GetCategoryPreviewQueryHandler : IRequestHandler<GetCategoryPreviewQuery, List<CategoryPreviewDto>>
    {
        private readonly INorthwindDbContext _context;

        public GetCategoryPreviewQueryHandler(INorthwindDbContext context)
        {
            _context = context;
        }

        public Task<List<CategoryPreviewDto>> Handle(GetCategoryPreviewQuery request, CancellationToken cancellationToken)
        {
            Thread.Sleep(500);

            // BUG: This nested projection results in N + 1
            return _context.Categories
                .Select(CategoryPreviewDto.Projection)
                .ToListAsync(cancellationToken);

            /*
            Temporary Fix - load data into memory and project in-memory.

            var data = await _context.Categories
                .Include(c => c.Products)
                .ToListAsync(cancellationToken);

            return data.AsQueryable()
                .Select(CategoryPreviewDto.Projection)
                .ToList();
             */
        }
    }
}
