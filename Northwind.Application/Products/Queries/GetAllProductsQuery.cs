using System.Collections.Generic;
using MediatR;
using Northwind.Application.Products.Models;

namespace Northwind.Application.Products.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}
