using MediatR;
using Northwind.Application.Products.Models;

namespace Northwind.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public ProductDto Product { get; set; }
    }
}
