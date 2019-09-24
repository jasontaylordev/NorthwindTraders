using MediatR;

namespace Northwind.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductViewModel>
    {
        public int Id { get; set; }
    }
}
