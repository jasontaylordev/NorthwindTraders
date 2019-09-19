using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Interfaces;

namespace Northwind.Application.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, IList<CategoryLookupModel>>
    {
        private readonly INorthwindDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesListQueryHandler(INorthwindDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<CategoryLookupModel>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories
                .ProjectTo<CategoryLookupModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return categories;
        }
    }
}