using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Customers.Models;
using Northwind.Application.Interfaces;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Customers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDetailModel>
    {
        private readonly NorthwindDbContext _context;
        private readonly INotificationService _notificationService;

        public CreateCustomerCommandHandler(
            NorthwindDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<CustomerDetailModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var model = request.Customer;

            var entity = new Customer
            {
                CustomerId = model.Id,
                Address = model.Address,
                City = model.City,
                CompanyName = model.CompanyName,
                ContactName = model.ContactName,
                ContactTitle = model.ContactTitle,
                Country = model.Country,
                Fax = model.Fax,
                Phone = model.Phone,
                PostalCode = model.PostalCode
            };

            _context.Customers.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            _notificationService.Send();

            return CustomerDetailModel.Create(entity);
        }
    }
}
