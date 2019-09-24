using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Categories.Queries.GetCategoriesList
{
    public class CategoriesListVm
    {
        public IList<CategoryLookup> Categories { get; set; }
    }
}
