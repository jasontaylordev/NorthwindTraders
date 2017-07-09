using System.Threading.Tasks;

namespace NorthwindTraders.Application.Customers.Commands.UpdateCustomer
{
    public interface IUpdateCustomerCommand
    {
        Task Execute(UpdateCustomerModel model);
    }
}
