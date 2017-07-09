using System.Threading.Tasks;

namespace NorthwindTraders.Application.Customers.Commands.CreateCustomer
{
    public interface ICreateCustomerCommand
    {
        Task Execute(CreateCustomerModel model);
    }
}
