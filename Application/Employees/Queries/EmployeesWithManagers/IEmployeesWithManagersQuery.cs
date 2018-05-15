using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindTraders.Application.Employees.Queries.EmployeesWithManagers
{
    public interface IEmployeesWithManagersQuery
    {
        Task<IEnumerable<EmployeeManagerModel>> Execute();
    }
}