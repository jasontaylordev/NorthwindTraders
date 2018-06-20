using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Products.Commands;
using Northwind.Application.Products.Models;
using Northwind.Application.Products.Queries;
using Northwind.WebApi.Infrastructure;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        // GET: api/Products
        [HttpGet]
        public Task<ProductsListViewModel> GetProducts()
        {
            return Mediator.Send(new GetAllProductsQuery());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Ok(await Mediator.Send(new GetProductQuery(id)));
        }

        // POST: api/Products
        [HttpPost]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostProduct([FromBody] CreateProductCommand command)
        {
            var viewModel = await Mediator.Send(command);

            return CreatedAtAction("GetProduct", new { id = viewModel.Product.ProductId }, viewModel);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PutProduct(
            [FromRoute] int id,
            [FromBody] UpdateProductCommand command)
        {
            if (id != command.Product.ProductId)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await Mediator.Send(new DeleteProductCommand(id));

            return NoContent();
        }
    }
}