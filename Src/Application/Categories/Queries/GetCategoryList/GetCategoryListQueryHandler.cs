using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, IList<CategoryLookupModel>>
    {
        private readonly INorthwindDbContext _context;

        public GetCategoryListQueryHandler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IList<CategoryLookupModel>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Categories
                .OrderBy(c => c.CategoryName)
                .Select(c =>
                    new CategoryLookupModel
                    {
                        Id = c.CategoryId,
                        Name = c.CategoryName
                    })
                .ToListAsync();
        }
    }
}
