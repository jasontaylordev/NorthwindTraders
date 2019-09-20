using AutoMapper;
using Northwind.Application.Infrastructure.Mappings;
using Northwind.Domain.Entities;

namespace Northwind.Application.Products.Queries.GetProductsFile
{
    public class ProductFileRecord : MapFrom<Product>
    {
        public string Category { get; set; }

        public string Name { get; set; }

        public decimal? UnitPrice { get; set; }

        public bool Discontinued { get; set; }

        public override void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductFileRecord>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.ProductName))
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category != null ? s.Category.CategoryName : string.Empty));
        }
    }
}
