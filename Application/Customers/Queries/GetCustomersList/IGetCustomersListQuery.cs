using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindTraders.Application.Customers.Queries.GetCustomersList
{
    public interface IGetCustomersListQuery
    {
        Task<IEnumerable<CustomerListModel>> Execute();
    }
}