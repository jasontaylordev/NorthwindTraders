using Northwind.Data;
using System;

namespace Northwind.Application.Employees.Commands.ChangeEmployeesManager
{
    public class ChangeEmployeesManagerCommand : IChangeEmployeesManagerCommand
    {
        private readonly NorthwindContext _context;

        public ChangeEmployeesManagerCommand(NorthwindContext context)
        {
            _context = context;
        }

        public void Execute(ChangeEmployeeManagerModel model)
        {
            throw new ArgumentException();
        }
    }
}
