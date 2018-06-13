using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Products.Commands;
using Northwind.Application.Products.Models;
using Northwind.Application.Products.Queries;

namespace Northwind.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Ok(await _mediator.Send(new GetProductQuery { Id = id }));
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] ProductDto product)
        {
            var newProduct = await _mediator.Send(new CreateProductCommand { Product = product });

            return CreatedAtAction("GetProduct", new { id = newProduct.ProductId }, newProduct);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromBody] ProductDto product)
        {
            return Ok(await _mediator.Send(new UpdateProductCommand { Product = product }));
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }
    }
}