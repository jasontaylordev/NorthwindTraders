using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Categories.Models;
using Northwind.Domain;
using Northwind.Persistence;

namespace Northwind.Application.Categories.Queries
{
    public class GetCategoryPreviewQueryHandler : IRequestHandler<GetCategoryPreviewQuery, CategoryPreviewDto>
    {
        private readonly NorthwindContext _context;

        public GetCategoryPreviewQueryHandler(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<CategoryPreviewDto> Handle(GetCategoryPreviewQuery request, CancellationToken cancellationToken)
        {
            Thread.Sleep(500);

            return await _context.Categories
                .Select(CategoryPreviewDto.Projection)
                .Where(c => c.CategoryId == request.CategoryId)
                .FirstAsync(cancellationToken);
        }
    }
}
