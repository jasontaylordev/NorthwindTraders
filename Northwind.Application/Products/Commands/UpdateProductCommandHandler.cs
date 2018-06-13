using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Exceptions;
using Northwind.Application.Products.Models;
using Northwind.Domain;
using Northwind.Persistence;

namespace Northwind.Application.Products.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly NorthwindDbContext _context;

        public UpdateProductCommandHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Product;

            var entity = await _context.Products
                .FindAsync(product.ProductId);

            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(Product), product.ProductId);
            }

            entity.ProductId = product.ProductId;
            entity.ProductName = product.ProductName;
            entity.CategoryId = product.CategoryId;
            entity.SupplierId = product.SupplierId;
            entity.UnitPrice = product.UnitPrice;
            entity.Discontinued = product.Discontinued;

            await _context.SaveChangesAsync(cancellationToken);

            return ProductDto.Create(entity);
        }
    }
}
