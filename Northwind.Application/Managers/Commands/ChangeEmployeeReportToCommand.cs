using MediatR;

namespace Northwind.Application.Managers.Commands
{
    public class ChangeEmployeeReportToCommand : IRequest
    {
        public int EmployeeId { get; set; }

        public int ManagerId { get; set; }
    }
}
