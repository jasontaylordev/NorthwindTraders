using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Application.Reports.Queries
{
    public interface IEmployeesWithManagersQuery
    {
        Task<IEnumerable<EmployeeManagerModel>> Execute();
    }
}