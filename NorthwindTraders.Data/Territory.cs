using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindTraders.Data
{
    public partial class Territory
    {
        public Territory()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
        }

        [Column("TerritoryID")]
        [MaxLength(20)]
        [Key]
        public string TerritoryId { get; set; }
        [Required]
        [Column(TypeName = "nchar(50)")]
        public string TerritoryDescription { get; set; }
        [Column("RegionID")]
        public int RegionId { get; set; }

        [InverseProperty("Territory")]
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
        [ForeignKey("RegionId")]
        [InverseProperty("Territories")]
        public virtual Region Region { get; set; }
    }
}
