using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Common.Interfaces;
using Northwind.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Application.Products.Queries.GetProductsFile
{
    public class GetProductsFileQueryHandler : IRequestHandler<GetProductsFileQuery, ProductsFileVm>
    {
        private readonly INorthwindDbContext _context;
        private readonly ICsvFileBuilder _fileBuilder;
        private readonly IMapper _mapper;
        private readonly IDateTime _dateTime;

        public GetProductsFileQueryHandler(INorthwindDbContext context, ICsvFileBuilder fileBuilder, IMapper mapper, IDateTime dateTime)
        {
            _context = context;
            _fileBuilder = fileBuilder;
            _mapper = mapper;
            _dateTime = dateTime;
        }

        public async Task<ProductsFileVm> Handle(GetProductsFileQuery request, CancellationToken cancellationToken)
        {
            var records = await _context.Products
                .ProjectTo<ProductRecordDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var fileContent = _fileBuilder.BuildProductsFile(records);

            var vm = new ProductsFileVm
            {
                Content = fileContent,
                ContentType = "text/csv",
                FileName = $"{_dateTime.Now:yyyy-MM-dd}-Products.csv"
            };

            return vm;
        }
    }
}
