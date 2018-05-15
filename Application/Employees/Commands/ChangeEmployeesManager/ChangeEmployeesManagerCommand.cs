using NorthwindTraders.Persistance;
using System;

namespace NorthwindTraders.Application.Employees.Commands.ChangeEmployeesManager
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
