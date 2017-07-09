using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindTraders.Domain
{
    public partial class Territory
    {
        public Territory()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
        }

        [Column("TerritoryID")]
        [MaxLength(20)]
        public string TerritoryId { get; set; }

        [Column("RegionID")]
        public int RegionId { get; set; }

        [Required]
        [MaxLength(50)]
        public string TerritoryDescription { get; set; }

        [InverseProperty("Territory")]
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }

        [InverseProperty("Territories")]
        public virtual Region Region { get; set; }
    }
}
