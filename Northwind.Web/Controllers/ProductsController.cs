using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Products.Commands;
using Northwind.Application.Products.Models;
using Northwind.Application.Products.Queries;

namespace Northwind.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        // GET: api/Products
        [HttpGet]
        public async Task<ProductsListViewModel> GetProducts()
        {
            return await Mediator.Send(new GetAllProductsQuery());
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
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostProduct([FromBody] CreateProductCommand command)
        {
            var newProduct = await Mediator.Send(command);

            return CreatedAtAction("GetProduct", new { id = newProduct.ProductId }, newProduct);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PutProduct([FromBody] UpdateProductCommand command)
        {
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