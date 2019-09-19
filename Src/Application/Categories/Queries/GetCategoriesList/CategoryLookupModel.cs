using AutoMapper;
using Northwind.Application.Infrastructure.Mappings;
using Northwind.Domain.Entities;

namespace Northwind.Application.Categories.Queries.GetCategoriesList
{
    public class CategoryLookupModel : MapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryLookupModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CategoryId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.CategoryName));
        }
    }
}
