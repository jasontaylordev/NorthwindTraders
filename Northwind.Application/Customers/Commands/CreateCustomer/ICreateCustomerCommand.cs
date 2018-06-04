using System.Threading.Tasks;

namespace Northwind.Application.Customers.Commands.CreateCustomer
{
    public interface ICreateCustomerCommand
    {
        Task Execute(CreateCustomerModel model);
    }
}
