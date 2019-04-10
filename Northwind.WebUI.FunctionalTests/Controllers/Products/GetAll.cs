using System.Net.Http;
using System.Threading.Tasks;
using Northwind.Application.Products.Queries.GetAllProducts;
using Northwind.WebUI.FunctionalTests.Common;
using Xunit;

namespace Northwind.WebUI.FunctionalTests.Controllers.Products
{
    public class GetAll : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetAll(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsProductsListViewModel()
        {
            var response = await _client.GetAsync("/api/products/getall");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<ProductsListViewModel>(response);

            Assert.IsType<ProductsListViewModel>(vm);
            Assert.NotEmpty(vm.Products);
        }
    }
}
