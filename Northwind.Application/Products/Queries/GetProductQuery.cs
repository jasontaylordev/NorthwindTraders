using MediatR;
using Northwind.Application.Products.Models;

namespace Northwind.Application.Products.Queries
{
    public class GetProductQuery : IRequest<ProductViewModel>
    {
        public GetProductQuery()
        {
        }

        public GetProductQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
