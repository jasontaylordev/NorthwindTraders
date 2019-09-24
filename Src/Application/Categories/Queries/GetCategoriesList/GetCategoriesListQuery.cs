using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace Northwind.Application.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<IList<CategoryLookupModel>>
    {
    }
}
