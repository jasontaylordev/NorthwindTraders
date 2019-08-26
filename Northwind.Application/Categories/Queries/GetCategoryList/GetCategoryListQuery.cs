using MediatR;
using System;
using System.Collections.Generic;

namespace Northwind.Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<IList<CategoryLookupModel>>
    {
    }
}
