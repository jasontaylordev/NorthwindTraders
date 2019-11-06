using Microsoft.EntityFrameworkCore;

namespace Dms.Persistence
{
    public class NorthwindDbContextFactory : DesignTimeDbContextFactoryBase<DmsDbContext>
    {
        protected override DmsDbContext CreateNewInstance(DbContextOptions<DmsDbContext> options)
        {
            return new DmsDbContext(options);
        }
    }
}
