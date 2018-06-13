using Dapper;
using Microsoft.EntityFrameworkCore;
using Northwind.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Persistence;

namespace Northwind.Application.Reports.Queries
{
    public class EmployeesWithManagersQuery : IEmployeesWithManagersQuery
    {
        private readonly NorthwindDbContext _context;

        public EmployeesWithManagersQuery(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeManagerModel>> Execute()
        {
            var sql = @"
SELECT e.EmployeeId as EmployeeId, e.FirstName as EmployeeFirstName, e.LastName as EmployeeLastName, e.Title as EmployeeTitle,
	   m.EmployeeId as ManagerId, m.FirstName as ManagerFirstName, m.LastName as ManagetLastName, m.Title as ManagerTitle
FROM employees AS e
JOIN employees AS m ON e.ReportsTo = m.EmployeeID
WHERE e.ReportsTo is not null";

            return await _context.Database.GetDbConnection()
                .QueryAsync<EmployeeManagerModel>(sql);
        }
    }
}
