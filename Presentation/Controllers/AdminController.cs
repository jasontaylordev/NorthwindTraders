using Microsoft.AspNetCore.Mvc;
using NorthwindTraders.Application.Employees.Commands.ChangeEmployeesManager;
using NorthwindTraders.Application.Employees.Queries.EmployeesWithManagers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindTraders.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AdminController
    {
        [HttpPost]
        public void ChangeEmployeeManager(
            [FromServices] IChangeEmployeesManagerCommand command,
            [FromBody] ChangeEmployeeManagerModel model)
        {
            command.Execute(model);
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeManagerModel>> EmployeeManagerReport(
            [FromServices] IEmployeesWithManagersQuery query
            )
        {
            return await query.Execute();
        }
    }
}
