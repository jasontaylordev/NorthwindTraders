using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Products.Commands.CreateProduct;
using Northwind.Application.Products.Commands.DeleteProduct;
using Northwind.Application.Products.Commands.UpdateProduct;
using Northwind.Application.Products.Queries.GetAllProducts;
using Northwind.Application.Products.Queries.GetProduct;
using Microsoft.AspNetCore.Http;

namespace Northwind.WebUI.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ProductsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProductQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateProductCommand command)
        {
            var productId = await Mediator.Send(command);

            return Ok(productId);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> Update([FromBody] UpdateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }
    }
}