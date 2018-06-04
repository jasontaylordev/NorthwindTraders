using System.Threading.Tasks;

namespace Northwind.Application.Customers.Queries.GetCustomerDetail 
{
	public interface IGetCustomerDetailQuery
    {
        Task<CustomerDetailModel> Execute(string id);
    }
}