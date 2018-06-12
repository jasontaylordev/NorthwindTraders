using System.Collections.Generic;
using MediatR;
using Northwind.Application.Products.Models;

namespace Northwind.Application.Products.Queries
{
    public class GetAllProductsQuery : IRequest, IRequest<IEnumerable<ProductDto>>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
