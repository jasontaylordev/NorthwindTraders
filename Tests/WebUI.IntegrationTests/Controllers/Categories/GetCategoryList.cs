using System.Threading.Tasks;
using Northwind.WebUI.IntegrationTests.Common;
using Xunit;

namespace Northwind.WebUI.IntegrationTests.Controllers.Categories
{
    public class GetCategoryList : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetCategoryList(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync("/api/categories/getall");

            response.EnsureSuccessStatusCode();
        }
    }
}
