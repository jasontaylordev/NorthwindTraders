using Northwind.Domain;
using System.Threading.Tasks;
using Northwind.Application.Interfaces;

namespace Northwind.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : ICreateCustomerCommand
    {
        public readonly NorthwindContext _context;
        private readonly INotificationService _notificationService;

        public CreateCustomerCommand(
            NorthwindContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task Execute(CreateCustomerModel model)
        {
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

            await _context.SaveChangesAsync();

            _notificationService.Send();
        }
    }
}
