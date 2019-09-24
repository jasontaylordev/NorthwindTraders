using System.Collections.Generic;

namespace Northwind.Application.Categories.Queries.GetCategoriesList
{
    public class CategoriesListVm
    {
        public IList<CategoryLookup> Categories { get; set; }
    }
}
