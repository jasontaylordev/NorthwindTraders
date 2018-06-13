using Northwind.Domain;
using System;
using Northwind.Persistence;

namespace Northwind.Application.Employees.Commands.ChangeEmployeesManager
{
    public class ChangeEmployeesManagerCommand : IChangeEmployeesManagerCommand
    {
        private readonly NorthwindDbContext _context;

        public ChangeEmployeesManagerCommand(NorthwindDbContext context)
        {
            _context = context;
        }

        public void Execute(ChangeEmployeeManagerModel model)
        {
            throw new ArgumentException();
        }
    }
}
