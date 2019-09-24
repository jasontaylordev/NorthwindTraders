using System.Threading.Tasks;
using Northwind.Application.Products.Queries.GetAllProducts;
using Northwind.WebUI.IntegrationTests.Common;
using Xunit;

namespace Northwind.WebUI.IntegrationTests.Controllers.Products
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

            var vm = await Utilities.GetResponseContent<ProductsListViewModel>(response);

            Assert.IsType<ProductsListViewModel>(vm);
            Assert.NotEmpty(vm.Products);
        }
    }
}
