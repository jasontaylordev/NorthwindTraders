using Northwind.Application.Reports.Queries;
using Northwind.Data;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.Reports
{
    public class EmployeesWithManagersQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnReport()
        {
            UseSqlite();

            var context = GetDbContext();
            NorthwindInitializer.Initialize(context);

            var query = new EmployeesWithManagersQuery(context);
            var result = await query.Execute();

            Assert.NotEmpty(result);
            Assert.Equal(8, result.Count());
            Assert.Contains(result, r => r.ManagerTitle == "Vice President, Sales");
            Assert.DoesNotContain(result, r => r.EmployeeTitle == "Vice President, Sales");
        }
    }
}
