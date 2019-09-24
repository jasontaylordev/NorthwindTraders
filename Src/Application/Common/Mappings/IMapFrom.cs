using AutoMapper;

namespace Northwind.Application.Common.Mappings
{
    public interface IMapFrom<T>
    {   
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
