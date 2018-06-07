using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Employees.Commands.ChangeEmployeesManager;
using Northwind.Application.Employees.Queries.EmployeesWithManagers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AdminController
    {
        [HttpPost]
        public void ChangeEmployeeManager([FromServices] IChangeEmployeesManagerCommand command, [FromBody] ChangeEmployeeManagerModel model)
        {
            command.Execute(model);
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeManagerModel>> EmployeeManagerReport([FromServices] IEmployeesWithManagersQuery query)
        {
            return await query.Execute();
        }
    }
}
