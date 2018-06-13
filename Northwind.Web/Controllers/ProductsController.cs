using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Products.Commands;
using Northwind.Application.Products.Models;
using Northwind.Application.Products.Queries;
using Northwind.Persistence;

namespace Northwind.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGetAllProductsQuery _getAllProductsQuery;
        private readonly IGetProductQuery _getProductQuery;
        private readonly ICreateProductCommand _createProductCommand;
        private readonly IUpdateProductCommand _updateProductCommand;
        private readonly IDeleteProductCommand _deleteProductCommand;

        public ProductsController(NorthwindDbContext context,
            IGetAllProductsQuery getAllProductsQuery,
            IGetProductQuery getProductQuery,
            ICreateProductCommand createProductCommand,
            IUpdateProductCommand updateProductCommand,
            IDeleteProductCommand deleteProductCommand)
        {
            _getAllProductsQuery = getAllProductsQuery;
            _getProductQuery = getProductQuery;
            _createProductCommand = createProductCommand;
            _updateProductCommand = updateProductCommand;
            _deleteProductCommand = deleteProductCommand;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            return await _getAllProductsQuery.Execute();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            return Ok(await _getProductQuery.Execute(id));
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] ProductDto product)
        {
            var newProduct = await _createProductCommand.Execute(product);

            return CreatedAtAction("GetProduct", new { id = newProduct.ProductId }, newProduct);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromBody] ProductDto product)
        {
            return Ok(await _updateProductCommand.Execute(product));
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            await _deleteProductCommand.Execute(id);

            return NoContent();
        }
    }
}