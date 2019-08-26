using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Domain.Entities;

namespace Northwind.Persistence.Configurations
{
    public class EmployeeTerritoryConfiguration : IEntityTypeConfiguration<EmployeeTerritory>
    {
        public void Configure(EntityTypeBuilder<EmployeeTerritory> builder)
        {
            builder.HasKey(e => new { e.EmployeeId, e.TerritoryId })
                .IsClustered(false);

            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            builder.Property(e => e.TerritoryId)
                .HasColumnName("TerritoryID")
                .HasMaxLength(20);

            builder.HasOne(d => d.Employee)
                .WithMany(p => p.EmployeeTerritories)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeTerritories_Employees");

            builder.HasOne(d => d.Territory)
                .WithMany(p => p.EmployeeTerritories)
                .HasForeignKey(d => d.TerritoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeTerritories_Territories");
        }
    }
}
