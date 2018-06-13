using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Categories.Models;
using Northwind.Application.Categories.Queries;

namespace Northwind.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryPreviewDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCategoryPreview(
            [FromQuery] GetCategoryPreviewQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
