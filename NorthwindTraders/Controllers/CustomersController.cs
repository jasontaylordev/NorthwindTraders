using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NorthwindTraders.Data;

namespace NorthwindTraders.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly NorthwindContext _context;

        public CustomersController(NorthwindContext context)
        {
            _context = context;
        }

        // GET api/customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _context.Customers.Select(c =>
                new Customer
                {
                    CustomerId = c.CustomerId,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    ContactTitle = c.ContactTitle,
                    Address = c.Address,
                    City = c.City,
                    Country = c.Country
                });
        }
    }
}