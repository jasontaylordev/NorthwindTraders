using Dapper;
using Microsoft.EntityFrameworkCore;
using NorthwindTraders.Persistance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindTraders.Application.Reports.Queries
{
    public class EmployeesWithManagersViewQuery
    {
        private readonly NorthwindContext _context;

        public EmployeesWithManagersViewQuery(NorthwindContext context)
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
