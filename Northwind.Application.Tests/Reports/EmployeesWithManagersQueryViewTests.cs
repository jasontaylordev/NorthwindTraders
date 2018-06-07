using Dapper;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Reports.Queries;
using Northwind.Data;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Northwind.Application.Tests.Reports
{
    public class EmployeesWithManagersQueryViewTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnReport()
        {
            UseSqlite();

            var context = GetDbContext();
            NorthwindInitializer.Initialize(context);

            context.Database.GetDbConnection().Execute(@"
CREATE VIEW viewEmployeesWithManagers(
        EmployeeFirstName, EmployeeLastName, EmployeeTitle,
        ManagerFirstName, ManagetLastName, ManagerTitle)
AS 
SELECT e.FirstName as EmployeeFirstName, e.LastName as EmployeeLastName, e.Title as EmployeeTitle,
        m.FirstName as ManagerFirstName, m.LastName as ManagetLastName, m.Title as ManagerTitle
FROM employees AS e
JOIN employees AS m ON e.ReportsTo = m.EmployeeID
WHERE e.ReportsTo is not null");

            var query = new EmployeesWithManagersViewQuery(context);
            var result = await query.Execute();

            Assert.NotEmpty(result);
            Assert.Equal(8, result.Count());
            Assert.Contains(result, r => r.ManagerTitle == "Vice President, Sales");
            Assert.DoesNotContain(result, r => r.EmployeeTitle == "Vice President, Sales");
        }
    }
}
