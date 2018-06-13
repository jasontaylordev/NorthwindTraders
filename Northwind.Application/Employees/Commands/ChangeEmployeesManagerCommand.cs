using MediatR;

namespace Northwind.Application.Employees.Commands
{
    public class ChangeEmployeesManagerCommand : IRequest
    {
        public int EmployeeId { get; set; }

        public int ManagerId { get; set; }
    }
}
