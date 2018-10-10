using FluentValidation;

namespace Northwind.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryValidator : AbstractValidator<GetCustomerDetailQuery>
    {
        public GetCustomerDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty().Length(5);
        }
    }
}
