using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindTraders.Data
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
            Orders = new HashSet<Order>();
        }

        [Column("EmployeeID")]
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string Title { get; set; }
        [MaxLength(25)]
        public string TitleOfCourtesy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HireDate { get; set; }
        [MaxLength(60)]
        public string Address { get; set; }
        [MaxLength(15)]
        public string City { get; set; }
        [MaxLength(15)]
        public string Region { get; set; }
        [MaxLength(10)]
        public string PostalCode { get; set; }
        [MaxLength(15)]
        public string Country { get; set; }
        [MaxLength(24)]
        public string HomePhone { get; set; }
        [MaxLength(4)]
        public string Extension { get; set; }
        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }
        [Column(TypeName = "ntext")]
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        [MaxLength(255)]
        public string PhotoPath { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<Order> Orders { get; set; }
        [ForeignKey("ReportsTo")]
        [InverseProperty("DirectReports")]
        public virtual Employee Manager { get; set; }

        [InverseProperty("Manager")]
        public virtual ICollection<Employee> DirectReports { get; set; }
    }
}
