using System.Net.Http;
using System.Threading.Tasks;
using Northwind.Application.Customers.Queries.GetCustomersList;
using Northwind.WebUI.FunctionalTests.Common;
using Xunit;

namespace Northwind.WebUI.FunctionalTests.Controllers.Customers
{
    public class GetAll : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetAll(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsCustomersListViewModel()
        {
            var response = await _client.GetAsync("/api/customers/getall");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<CustomersListViewModel>(response);

            Assert.IsType<CustomersListViewModel>(vm);
            Assert.NotEmpty(vm.Customers);
        }
    }
}
