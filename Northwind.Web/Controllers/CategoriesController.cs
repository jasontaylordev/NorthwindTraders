using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Categories.Models;
using Northwind.Application.Categories.Queries;
using Northwind.Web.Infrastructure;

namespace Northwind.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryPreviewDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCategoryPreview(
            [FromQuery] GetCategoryPreviewQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
