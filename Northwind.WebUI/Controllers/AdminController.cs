using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Employees.Commands;
using Northwind.Application.Employees.Models;
using Northwind.Application.Employees.Queries;
using Microsoft.AspNetCore.Http;

namespace Northwind.WebUI.Controllers
{
    public class AdminController : BaseController
    {
        [HttpGet]
        public Task<IEnumerable<EmployeeManagerModel>> EmployeeManagerReport()
        {
            return Mediator.Send(new EmployeesWithManagersQuery());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public IActionResult ChangeEmployeeManager(ChangeEmployeesManagerCommand command)
        {
            Mediator.Send(command);

            return NoContent();
        }
    }
}
