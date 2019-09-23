using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Northwind.Application.Customers.Commands.UpdateCustomer;
using Northwind.WebUI.IntegrationTests.Common;
using Xunit;

namespace Northwind.WebUI.IntegrationTests.Controllers.Customers
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenUpdateCustomerCommand_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

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

            var response = await client.PutAsync($"/api/customers/update/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenUpdateCustomerCommandWithInvalidId_ReturnsNotFoundStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

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

            var response = await client.PutAsync($"/api/customers/update/{invalidCommand.Id}", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
