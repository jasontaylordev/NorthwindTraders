using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Customers.Models;
using Northwind.Application.Interfaces;
using Northwind.Application.Notifications.Models;
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
            var entity = new Customer
            {
                CustomerId = request.Id,
                Address = request.Address,
                City = request.City,
                CompanyName = request.CompanyName,
                ContactName = request.ContactName,
                ContactTitle = request.ContactTitle,
                Country = request.Country,
                Fax = request.Fax,
                Phone = request.Phone,
                PostalCode = request.PostalCode
            };

            _context.Customers.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            _notificationService.Send(new Message
            {
                From = "jasontaylor@ssw.com.au",
                To = "jasontaylor@ssw.com.au",
                Subject = "MediatR - Events",
                Body = "Remember to update the create customer command" +
                       "handler demo to use a MediatR event."
            });

            return CustomerDetailModel.Create(entity);
        }
    }
}
