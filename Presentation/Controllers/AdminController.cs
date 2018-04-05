using Microsoft.AspNetCore.Mvc;

namespace NorthwindTraders.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AdminController
    {
        //[HttpPost]
        //public void ChangeEmployeeManager(
        //    [FromServices] IChangeEmployeeReportToCommand command,
        //    [FromBody] EmployeeUnderManagerModel model)
        //{
        //    command.Execute(model);
        //}

        //[HttpGet]
        //public Task<IEnumerable<EmployeeManagerModel>> EmployeeManagerReport(
        //    [FromServices] IEmployeesWithManagersQuery query
        //    )
        //{
        //    return query.Execute();
        //}
    }
}
