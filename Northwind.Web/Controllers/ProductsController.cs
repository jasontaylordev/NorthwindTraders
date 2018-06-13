using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Products.Commands;
using Northwind.Application.Products.Models;
using Northwind.Application.Products.Queries;

namespace Northwind.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetProducts(
            [FromServices] IGetAllProductsQuery query)
        {
            return await query.Execute();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(
            [FromServices] IGetProductQuery query,
            int id)
        {
            return Ok(await query.Execute(id));
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProduct(
            [FromServices] ICreateProductCommand command,
            [FromBody] ProductDto product)
        {
            var newProduct = await command.Execute(product);

            return CreatedAtAction("GetProduct", new { id = newProduct.ProductId }, newProduct);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(
            [FromServices] IUpdateProductCommand command,
            [FromBody] ProductDto product)
        {
            return Ok(await command.Execute(product));
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(
            [FromServices] IDeleteProductCommand command,
            int id)
        {
            await command.Execute(id);

            return NoContent();
        }
    }
}