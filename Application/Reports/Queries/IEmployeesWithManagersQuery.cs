using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindTraders.Application.Reports.Queries
{
    public interface IEmployeesWithManagersQuery
    {
        Task<IEnumerable<EmployeeManagerModel>> Execute();
    }
}