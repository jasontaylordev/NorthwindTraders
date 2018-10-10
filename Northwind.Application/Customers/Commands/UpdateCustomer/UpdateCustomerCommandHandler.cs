using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Exceptions;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly NorthwindDbContext _context;

        public UpdateCustomerCommandHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .SingleAsync(c => c.CustomerId == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            entity.Address = request.Address;
            entity.City = request.City;
            entity.CompanyName = request.CompanyName;
            entity.ContactName = request.ContactName;
            entity.ContactTitle = request.ContactTitle;
            entity.Country = request.Country;
            entity.Fax = request.Fax;
            entity.Phone = request.Phone;
            entity.PostalCode = request.PostalCode;

            _context.Customers.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
