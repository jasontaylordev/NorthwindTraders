using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Application.Employees.Queries.EmployeesWithManagers
{
    public interface IEmployeesWithManagersQuery
    {
        Task<IEnumerable<EmployeeManagerModel>> Execute();
    }
}