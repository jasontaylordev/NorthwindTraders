using MediatR;
using Northwind.Application.Products.Models;

namespace Northwind.Application.Products.Commands
{
    public class UpdateProductCommand : IRequest<ProductDto>
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        public bool Discontinued { get; set; }
    }
}
