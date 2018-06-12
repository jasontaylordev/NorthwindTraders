using MediatR;
using Northwind.Application.Products.Models;

namespace Northwind.Application.Products.Queries
{
    public class GetProductQuery : IRequest<ProductDto>
    {
        public int ProductId { get; set; }
    }
}
