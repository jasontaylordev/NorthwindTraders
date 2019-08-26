using AutoMapper;
using Northwind.Application.Interfaces.Mapping;
using Northwind.Domain.Entities;

namespace Northwind.Application.Customers.Queries.GetCustomersList
{
    public class CustomerLookupModel : IHaveCustomMapping
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Customer, CustomerLookupModel>()
                .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.CustomerId))
                .ForMember(cDTO => cDTO.Name, opt => opt.MapFrom(c => c.CompanyName));
        }
    }
}
