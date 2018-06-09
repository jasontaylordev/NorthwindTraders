using Northwind.Domain;
using System;
using System.Linq;

namespace Northwind.Application.Managers.Commands
{
    public class ChangeEmployeeReportToCommand : IChangeEmployeeReportToCommand
    {
        private readonly NorthwindContext _context;

        public ChangeEmployeeReportToCommand(NorthwindContext context)
        {
            _context = context;
        }

        public void Execute(EmployeeUnderManagerModel model)
        {
            if (model.ManagerId == model.EmployeeId)
            {
                throw new ArgumentException("Employee and manager ID must not be the same", nameof(model));
            }

            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == model.EmployeeId);
            var managerExists = _context.Employees.Any(e => e.EmployeeId == model.ManagerId);
            if (employee == null || !managerExists)
            {
                throw new ArgumentException("Employee or manager not existing.", nameof(model));
            }

            employee.ReportsTo = model.ManagerId;

            _context.SaveChanges();
        }
    }
}
