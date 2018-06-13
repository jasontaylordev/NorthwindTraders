using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Persistence;

namespace Northwind.Application.Managers.Commands
{
    public class ChangeEmployeeReportToCommandHandler : IRequestHandler<ChangeEmployeeReportToCommand>
    {
        private readonly NorthwindDbContext _context;

        public ChangeEmployeeReportToCommandHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ChangeEmployeeReportToCommand request, CancellationToken cancellationToken)
        {
            if (request.ManagerId == request.EmployeeId)
            {
                throw new ArgumentException("Employee and Manager Id must not be the same", nameof(ChangeEmployeeReportToCommand));
            }

            var employee = await _context.Employees
                .FindAsync(request.EmployeeId);

            var managerExists = await _context.Employees
                .AnyAsync(e => e.EmployeeId == request.ManagerId, cancellationToken);

            if (employee == null || !managerExists)
            {
                // TODO: Handle each case separately
                throw new ArgumentException("Employee or manager not existing.", nameof(ChangeEmployeeReportToCommand));
            }

            employee.ReportsTo = request.ManagerId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
