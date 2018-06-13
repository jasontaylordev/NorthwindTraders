using Microsoft.EntityFrameworkCore;
using System;
using Northwind.Persistence;

namespace Northwind.Application.Tests
{
    public class TestBase
    {
        public NorthwindDbContext GetDbContext(bool useSqlLite = false)
        {
            var builder = new DbContextOptionsBuilder<NorthwindDbContext>();
            if (useSqlLite)
            {
                builder.UseSqlite("DataSource=:memory:", x => { });
            }
            else
            {
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }

            var dbContext = new NorthwindDbContext(builder.Options);
            if (useSqlLite)
            {
                // SQLite needs to open connection to the DB.
                // Not required for in-memory-database.
                dbContext.Database.OpenConnection();
            }

            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
