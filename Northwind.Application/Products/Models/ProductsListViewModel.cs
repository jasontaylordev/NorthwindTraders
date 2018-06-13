using System.Collections.Generic;

namespace Northwind.Application.Products.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductDto> Products { get; set; }

        public bool CreateEnabled { get; set; }
    }
}
