using Northwind.Application.Reports.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Northwind.Persistence;
using Xunit;

namespace Northwind.Application.Tests.Reports
{
    public class EmployeesWithManagersQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnReport()
        {
            var context = GetDbContext(useSqlLite: true);
            NorthwindInitializer.Initialize(context);

            var query = new EmployeesWithManagersQuery();
            var queryHandler = new EmployeesWithManagersQueryHandler(context);
            var result = await queryHandler.Handle(query, CancellationToken.None);

            Assert.NotEmpty(result);
            Assert.Equal(8, result.Count());
            Assert.Contains(result, r => r.ManagerTitle == "Vice President, Sales");
            Assert.DoesNotContain(result, r => r.EmployeeTitle == "Vice President, Sales");
        }
    }
}
