using System.Threading.Tasks;

namespace NorthwindTraders.Application.Customers.Queries.GetCustomerDetail 
{
	public interface IGetCustomerDetailQuery
    {
        Task<CustomerDetailModel> Execute(string id);
    }
}