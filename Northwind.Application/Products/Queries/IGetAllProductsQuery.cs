using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Application.Products.Models;

namespace Northwind.Application.Products.Queries
{
    public interface IGetAllProductsQuery
    {
        Task<IEnumerable<ProductDto>> Execute();
    }
}