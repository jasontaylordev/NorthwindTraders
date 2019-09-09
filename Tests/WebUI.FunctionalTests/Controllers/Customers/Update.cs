using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Northwind.Application.Customers.Commands.UpdateCustomer;
using Northwind.WebUI.FunctionalTests.Common;
using Xunit;

namespace Northwind.WebUI.FunctionalTests.Controllers.Customers
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenUpdateCustomerCommand_ReturnsSuccessStatusCode()
        {
            var command = new UpdateCustomerCommand
            {
                Id = "ALFKI",
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

            var response = await _client.PutAsync($"/api/customers/update/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenUpdateCustomerCommandWithInvalidId_ReturnsNotFoundStatusCode()
        {
            var invalidCommand = new UpdateCustomerCommand
            {
                Id = "AAAAA",
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

            var content = Utilities.GetRequestContent(invalidCommand);

            var response = await _client.PutAsync($"/api/customers/update/{invalidCommand.Id}", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
