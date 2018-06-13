using System.Threading.Tasks;
using Northwind.Application.Products.Models;

namespace Northwind.Application.Products.Commands
{
    public interface IUpdateProductCommand
    {
        Task<ProductDto> Execute(ProductDto product);
    }
}