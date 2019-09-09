using Microsoft.EntityFrameworkCore;
using Northwind.Persistence.Infrastructure;

namespace Northwind.Persistence
{
    public class NorthwindDbContextFactory : DesignTimeDbContextFactoryBase<NorthwindDbContext>
    {
        protected override NorthwindDbContext CreateNewInstance(DbContextOptions<NorthwindDbContext> options)
        {
            return new NorthwindDbContext(options);
        }
    }
}
