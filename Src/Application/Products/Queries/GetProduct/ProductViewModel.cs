using AutoMapper;
using Northwind.Application.Infrastructure.Mappings;
using Northwind.Domain.Entities;

namespace Northwind.Application.Products.Queries.GetProduct
{
    public class ProductViewModel : MapFrom<Product>
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? SupplierId { get; set; }

        public string SupplierCompanyName { get; set; }

        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }

        public bool Discontinued { get; set; }

        public bool EditEnabled { get; set; }

        public bool DeleteEnabled { get; set; }

        public override void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductViewModel>()
                .ForMember(d => d.EditEnabled, opt => opt.MapFrom<PermissionsResolver>())
                .ForMember(d => d.DeleteEnabled, opt => opt.MapFrom<PermissionsResolver>())
                .ForMember(d => d.SupplierCompanyName, opt => opt.MapFrom(s => s.Supplier != null ? s.Supplier.CompanyName : string.Empty))
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category != null ? s.Category.CategoryName : string.Empty));
        }

        public class PermissionsResolver : IValueResolver<Product, ProductViewModel, bool>
        {
            // TODO: Inject your services and helper here
            public PermissionsResolver()
            {
               
            }

            public bool Resolve(Product source, ProductViewModel dest, bool destMember, ResolutionContext context)
            {
                    return false;
            }
        }
    }
}
