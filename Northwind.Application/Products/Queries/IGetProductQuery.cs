using System.Threading.Tasks;
using Northwind.Application.Products.Models;

namespace Northwind.Application.Products.Queries
{
    public interface IGetProductQuery
    {
        Task<ProductDto> Execute(int id);
    }
}