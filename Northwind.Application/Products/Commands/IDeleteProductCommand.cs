using System.Threading.Tasks;

namespace Northwind.Application.Products.Commands
{
    public interface IDeleteProductCommand
    {
        Task Execute(int id);
    }
}