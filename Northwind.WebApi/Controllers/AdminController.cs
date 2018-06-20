using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Application.Employees.Commands;
using Northwind.Application.Employees.Models;
using Northwind.Application.Employees.Queries;
using Northwind.WebApi.Infrastructure;

namespace Northwind.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AdminController : BaseController
    {
        [HttpGet("[action]")]
        public Task<IEnumerable<EmployeeManagerModel>> EmployeeManagerReport()
        {
            return Mediator.Send(new EmployeesWithManagersQuery());
        }

        [HttpPost]
        public IActionResult ChangeEmployeeManager(ChangeEmployeesManagerCommand command)
        {
            Mediator.Send(command);

            return NoContent();
        }
    }
}
