using MediatR;

namespace Northwind.Application.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<CategoriesListVm>
    {
    }
}
