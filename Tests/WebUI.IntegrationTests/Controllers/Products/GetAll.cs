using System.Threading.Tasks;
using Dms.WebUI.IntegrationTests.Common;
using Dms.Application.Products.Queries.GetProductsList;
using Xunit;

namespace Dms.WebUI.IntegrationTests.Controllers.Products
{
    public class GetAll : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetAll(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsProductsListViewModel()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync("/api/products/getall");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<ProductsListVm>(response);

            Assert.IsType<ProductsListVm>(vm);
            Assert.NotEmpty(vm.Products);
        }
    }
}
