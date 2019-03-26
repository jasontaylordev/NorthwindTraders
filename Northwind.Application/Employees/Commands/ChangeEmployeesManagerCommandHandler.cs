using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Northwind.Application.Employees.Commands
{
    public class ChangeEmployeesManagerCommandHandler : IRequestHandler<ChangeEmployeesManagerCommand>
    {
        public Task<Unit> Handle(ChangeEmployeesManagerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
