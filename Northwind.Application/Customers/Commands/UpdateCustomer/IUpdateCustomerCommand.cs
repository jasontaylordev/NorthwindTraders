using System.Threading.Tasks;

namespace Northwind.Application.Customers.Commands.UpdateCustomer
{
    public interface IUpdateCustomerCommand
    {
        Task Execute(UpdateCustomerModel model);
    }
}
