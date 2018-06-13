using System.Threading.Tasks;
using Northwind.Application.Products.Models;

namespace Northwind.Application.Products.Commands
{
    public interface ICreateProductCommand
    {
        Task<ProductDto> Execute(ProductDto product);
    }
}