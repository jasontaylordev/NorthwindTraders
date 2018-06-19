using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Reports.Models;
using Northwind.Persistence;

namespace Northwind.Application.Reports.Queries
{
    public class EmployeesWithManagersQueryHandler : IRequestHandler<EmployeesWithManagersQuery, IEnumerable<EmployeeManagerModel>>
    {
        private readonly NorthwindDbContext _context;

        public EmployeesWithManagersQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<EmployeeManagerModel>> Handle(EmployeesWithManagersQuery request, CancellationToken cancellationToken)
        {
            var sql = @"
SELECT e.EmployeeId as EmployeeId, e.FirstName as EmployeeFirstName, e.LastName as EmployeeLastName, e.Title as EmployeeTitle,
	   m.EmployeeId as ManagerId, m.FirstName as ManagerFirstName, m.LastName as ManagerLastName, m.Title as ManagerTitle
FROM employees AS e
JOIN employees AS m ON e.ReportsTo = m.EmployeeID
WHERE e.ReportsTo is not null";

            return _context.Database.GetDbConnection()
                .QueryAsync<EmployeeManagerModel>(sql);
        }
    }
}
