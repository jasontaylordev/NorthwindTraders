using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindTraders.Domain
{
    public partial class CustomerCustomerDemo
    {
        [Column("CustomerID")]
        [MaxLength(5)]
        public string CustomerId { get; set; }

        [Column("CustomerTypeID")]
        [MaxLength(10)]
        public string CustomerTypeId { get; set; }

        [InverseProperty("CustomerCustomerDemo")]
        public virtual Customer Customer { get; set; }

        [InverseProperty("CustomerCustomerDemo")]
        public virtual CustomerDemographics CustomerType { get; set; }
    }
}
