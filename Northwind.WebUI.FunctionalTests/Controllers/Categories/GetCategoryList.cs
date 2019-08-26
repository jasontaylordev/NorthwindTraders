using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Northwind.Application.Categories.Queries.GetCategoryList;
using Northwind.WebUI.FunctionalTests.Common;
using Xunit;

namespace Northwind.WebUI.FunctionalTests.Controllers.Categories
{
    public class GetCategoryList : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetCategoryList(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsIEnumerableOfCategoryPreviewDto()
        {
            var response = await _client.GetAsync("/api/categories/getall");

            response.EnsureSuccessStatusCode();

            var categories = await Utilities.GetResponseContent<IList<CategoryLookupModel>>(response);

            Assert.NotEmpty(categories);
        }
    }
}
