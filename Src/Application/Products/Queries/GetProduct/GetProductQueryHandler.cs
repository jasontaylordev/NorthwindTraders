using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Exceptions;
using Northwind.Application.Interfaces;
using Northwind.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : MediatR.IRequestHandler<GetProductQuery, ProductViewModel>
    {
        private readonly INorthwindDbContext _context;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(INorthwindDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductViewModel>(await _context
                .Products.Where(p => p.ProductId == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            // TODO: Set view model state based on user permissions.
            product.EditEnabled = true;
            product.DeleteEnabled = false;

            return product;
        }
    }
}
