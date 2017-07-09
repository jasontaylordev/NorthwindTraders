using System.Threading.Tasks;

namespace NorthwindTraders.Application.Customers.Commands.DeleteCustomer
{
    public interface IDeleteCustomerCommand
    {
        Task Execute(string id);
    }
}
