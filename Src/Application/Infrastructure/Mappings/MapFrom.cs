using AutoMapper;

namespace Northwind.Application.Infrastructure.Mappings
{
    public abstract class MapFrom<T>
    {   
        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(T), GetType());
        }
    }
}
