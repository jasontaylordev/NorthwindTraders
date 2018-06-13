namespace Northwind.Application.Products.Models
{
    public class ProductViewModel
    {
        public ProductDto Product { get; set; }

        public bool EditEnabled { get; set; }

        public bool DeleteEnabled { get; set; }
    }
}
