using Microsoft.AspNetCore.Mvc;
using NorthwindTraders.Application.Managers.Commands;
using NorthwindTraders.Application.Reports.Queries;
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
            [FromServices] IChangeEmployeeReportToCommand command,
            [FromBody] EmployeeUnderManagerModel model)
        {
            command.Execute(model);
        }

        [HttpGet]
        public Task<IEnumerable<EmployeeManagerModel>> EmployeeManagerReport(
            [FromServices] IEmployeesWithManagersQuery query
            )
        {
            return query.Execute();
        }
    }
}
