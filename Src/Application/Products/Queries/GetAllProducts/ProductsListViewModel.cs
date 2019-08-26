using System.Collections.Generic;

namespace Northwind.Application.Products.Queries.GetAllProducts
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductDto> Products { get; set; }

        public bool CreateEnabled { get; set; }
    }
}
