using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Products.Models;
using Northwind.Application.Products.Queries;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductViewModel>
    {
        private readonly NorthwindDbContext _context;
        private readonly IMediator _mediator;

        public CreateProductCommandHandler(
            NorthwindDbContext context,
            IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ProductViewModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                ProductName = request.ProductName,
                CategoryId = request.CategoryId,
                SupplierId = request.SupplierId,
                UnitPrice = request.UnitPrice,
                Discontinued = request.Discontinued
            };

            _context.Products.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return await _mediator.Send(new GetProductQuery(entity.ProductId), cancellationToken);
        }
    }
}
