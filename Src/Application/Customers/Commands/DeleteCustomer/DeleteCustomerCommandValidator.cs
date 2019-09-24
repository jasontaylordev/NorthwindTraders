using FluentValidation;

namespace Northwind.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().Length(5);
        }
    }
}
