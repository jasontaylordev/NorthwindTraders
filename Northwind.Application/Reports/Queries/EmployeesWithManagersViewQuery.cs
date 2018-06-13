using Dapper;
using Microsoft.EntityFrameworkCore;
using Northwind.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Persistence;

namespace Northwind.Application.Reports.Queries
{
    public class EmployeesWithManagersViewQuery
    {
        private readonly NorthwindDbContext _context;

        public EmployeesWithManagersViewQuery(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeManagerModel>> Execute()
        {
            var sql = "select * from viewEmployeesWithManagers";
            return await _context.Database.GetDbConnection()
                .QueryAsync<EmployeeManagerModel>(sql);
        }
    }
}
