using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Customers.Models;
using Northwind.Application.Customers.Validators;
using Northwind.Application.Exceptions;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Customers.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDetailModel>
    {
        private readonly NorthwindDbContext _context;

        public UpdateCustomerCommandHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerDetailModel> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var model = request.Customer;

            var validator = new UpdateCustomerModelValidator();
            var validationResult = validator.Validate(model);
            if (!validationResult.IsValid)
            {
                throw new InvalidModelException(nameof(model));
            }

            var entity = await _context.Customers
                .SingleAsync(c => c.CustomerId == model.Id, cancellationToken);

            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(Customer), request.Customer.Id);
            }

            entity.Address = model.Address;
            entity.City = model.City;
            entity.CompanyName = model.CompanyName;
            entity.ContactName = model.ContactName;
            entity.ContactTitle = model.ContactTitle;
            entity.Country = model.Country;
            entity.Fax = model.Fax;
            entity.Phone = model.Phone;
            entity.PostalCode = model.PostalCode;

            _context.Customers.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return CustomerDetailModel.Create(entity);
        }
    }
}
