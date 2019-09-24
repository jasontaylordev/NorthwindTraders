using MediatR;

namespace Northwind.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        public bool Discontinued { get; set; }
    }
}
