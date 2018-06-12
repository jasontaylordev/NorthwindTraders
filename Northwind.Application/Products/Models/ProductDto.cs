using System;
using System.Linq.Expressions;
using Northwind.Domain;

namespace Northwind.Application.Products.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public string CategoryName { get; set; }

        public string SupplierCompanyName { get; set; }

        public bool Discontinued { get; set; }

        public static Expression<Func<Product, ProductDto>> Projection
        {
            get
            {
                return p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    UnitPrice = p.UnitPrice,
                    CategoryName = p.Category.CategoryName,
                    SupplierCompanyName = p.Supplier.CompanyName,
                    Discontinued = p.Discontinued,
                };
            }
        }

        public static ProductDto Create(Product product)
        {
            return Projection.Compile().Invoke(product);
        }
    }
}