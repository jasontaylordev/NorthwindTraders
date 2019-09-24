using Northwind.Application.Customers.Queries.GetCustomerDetail;
using Northwind.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Northwind.Application.UnitTests.Infrastructure;
using Xunit;

namespace Northwind.Application.UnitTests.Customers.Queries
{
    [Collection("QueryCollection")]
    public class GetCustomerDetailQueryHandlerTests
    { 
        private readonly NorthwindDbContext _context;

        public GetCustomerDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }    

        [Fact]
        public async Task GetCustomerDetail()
        {
            var sut = new GetCustomerDetailQueryHandler(_context);

            var result = await sut.Handle(new GetCustomerDetailQuery { Id = "JASON" }, CancellationToken.None);

            result.ShouldBeOfType<CustomerDetailModel>();
            result.Id.ShouldBe("JASON");
        }
    }
}
