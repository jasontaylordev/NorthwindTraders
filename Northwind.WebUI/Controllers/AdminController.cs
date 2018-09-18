using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Employees.Commands;
using Northwind.Application.Employees.Models;
using Northwind.Application.Employees.Queries;
using Northwind.WebUI.Infrastructure;

namespace Northwind.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
