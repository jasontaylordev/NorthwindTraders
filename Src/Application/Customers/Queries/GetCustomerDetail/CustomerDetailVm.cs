using AutoMapper;
using Northwind.Application.Common.Mappings;
using Northwind.Domain.Entities;

namespace Northwind.Application.Customers.Queries.GetCustomerDetail
{
    public class CustomerDetailVm : IMapFrom<Customer>
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Country { get; set; }
        public string Fax { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CustomerId));
        }

        /*
         * 
         * A good example of how AutoMapper can help.
         * 
        public static Expression<Func<Customer, CustomerDetailVm>> Projection
        {
            get
            {
                return customer => new CustomerDetailVm
                {
                    Id = customer.CustomerId,
                    Address = customer.Address,
                    City = customer.City,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Country = customer.Country,
                    Fax = customer.Fax,
                    Phone = customer.Phone,
                    PostalCode = customer.PostalCode,
                    Region = customer.Region
                };
            }
        }

        public static CustomerDetailVm Create(Customer customer)
        {
            return Projection.Compile().Invoke(customer);
        }
        */
    }
}
