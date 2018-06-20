using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Northwind.Application.Customers.Commands;
using Northwind.Application.Customers.Models;
using Northwind.Application.Customers.Queries;
using Northwind.WebApi.Infrastructure;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        // GET api/customers
        [HttpGet]
        public Task<List<CustomerListModel>> Get()
        {
            return Mediator.Send(new GetCustomerListQuery());
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await Mediator.Send(new GetCustomerDetailQuery { Id = id }));
        }

        // POST api/customers
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCustomerModel customer)
        {
            var newCustomer = await Mediator.Send(new CreateCustomerCommand { Customer = customer });

            return CreatedAtRoute("Create", new { newCustomer.Id }, newCustomer);
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody]UpdateCustomerModel customer)
        {
            if (customer == null || customer.Id != id)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(new UpdateCustomerCommand { Customer = customer }));
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteCustomerCommand {Id = id});

            return NoContent();
        }
    }
}