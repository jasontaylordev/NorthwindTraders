using Northwind.Application.Customers.Queries.GetCustomersList;
using Northwind.Application.Tests.Infrastructure;
using Northwind.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NorthwindTraders.Application.UnitTests.Infrastructure
{
    [Collection("QueryCollection")]
    public class GetCustomersListQueryHandlerTests
    {
        private readonly NorthwindDbContext _context;

        public GetCustomersListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task GetCustomersTest()
        {
            var sut = new GetCustomersListQueryHandler(_context);

            var result = await sut.Handle(new GetCustomersListQuery(), CancellationToken.None);

            result.ShouldBeOfType<CustomersListViewModel>();

            result.Customers.Count.ShouldBe(3);
        }
    }
}