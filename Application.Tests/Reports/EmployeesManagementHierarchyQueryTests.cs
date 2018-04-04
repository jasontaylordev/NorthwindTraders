using NorthwindTraders.Application.Reports.Queries;
using NorthwindTraders.Persistance;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.Reports
{
    public class EmployeesManagementHierarchyQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnReport()
        {
            UseSqlite();

            var context = GetDbContext();
            NorthwindInitializer.Initialize(context);

            var query = new EmployeesManagementHierarchyQuery(context);
            var result = await query.Execute();

            Assert.NotEmpty(result);
            Assert.Equal(8, result.Count());
            Assert.Contains(result, r => r.ManagerTitle == "Vice President, Sales");
            Assert.DoesNotContain(result, r => r.EmployeeTitle == "Vice President, Sales");
        }
    }
}
