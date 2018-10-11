using System;
using System.Linq.Expressions;
using Northwind.Domain.Entities;

namespace Northwind.Application.Products.Queries.GetAllProducts
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? SupplierId { get; set; }

        public string SupplierCompanyName { get; set; }

        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }

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
                    SupplierId = p.SupplierId,
                    SupplierCompanyName = p.Supplier != null
                        ? p.Supplier.CompanyName : string.Empty,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null
                        ? p.Category.CategoryName : string.Empty,
                    Discontinued = p.Discontinued
                };
            }
        }

        public static ProductDto Create(Product product)
        {
            return Projection.Compile().Invoke(product);
        }
    }
}