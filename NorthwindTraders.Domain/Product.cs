using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindTraders.Domain
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Column("ProductID")]
        public int ProductId { get; set; }

        [Column("CategoryID")]
        public int? CategoryId { get; set; }

        public bool Discontinued { get; set; }

        [Required]
        [MaxLength(40)]
        public string ProductName { get; set; }

        [MaxLength(20)]
        public string QuantityPerUnit { get; set; }

        public short? ReorderLevel { get; set; }

        [Column("SupplierID")]
        public int? SupplierId { get; set; }
        
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }
        
        [InverseProperty("Product")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [InverseProperty("Products")]
        public virtual Category Category { get; set; }

        [InverseProperty("Products")]
        public virtual Supplier Supplier { get; set; }
    }
}
