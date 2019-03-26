using System.Net.Http;
using System.Threading.Tasks;
using Northwind.Application.Customers.Commands.CreateCustomer;
using Northwind.WebUI.FunctionalTests.Common;
using Xunit;

namespace Northwind.WebUI.FunctionalTests.Controllers.Customers
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenCreateCustomerCommand_ReturnsSuccessStatusCode()
        {
            var command = new CreateCustomerCommand
            {
                Id = "ABCDE",
                Address = "Obere Str. 57",
                City = "Berlin",
                CompanyName = "Alfreds Futterkiste",
                ContactName = "Maria Anders",
                ContactTitle = "Sales Representative",
                Country = "Germany",
                Fax = "030-0076545",
                Phone = "030-0074321",
                PostalCode = "12209"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PostAsync($"/api/customers/create", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
