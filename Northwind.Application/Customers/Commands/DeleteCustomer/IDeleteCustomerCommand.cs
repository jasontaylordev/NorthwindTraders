using System.Threading.Tasks;

namespace Northwind.Application.Customers.Commands.DeleteCustomer
{
    public interface IDeleteCustomerCommand
    {
        Task Execute(string id);
    }
}
