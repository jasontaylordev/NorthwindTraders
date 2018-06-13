using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Persistence;

namespace Northwind.Application.Employees.Commands
{
    public class ChangeEmployeesManagerCommandHandler : IRequestHandler<ChangeEmployeesManagerCommand>
    {
        private readonly NorthwindDbContext _context;

        public ChangeEmployeesManagerCommandHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(ChangeEmployeesManagerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
