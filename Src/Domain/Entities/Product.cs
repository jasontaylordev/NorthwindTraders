using System.Collections.Generic;
using Northwind.Domain.Common;

namespace Northwind.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; private set; }
    }
}
