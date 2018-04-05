using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NorthwindTraders.Persistance;
using System;

namespace Application.Tests
{
    public class TestBase
    {
        // https://www.thereformedprogrammer.net/using-in-memory-databases-for-unit-testing-ef-core-applications/
        private bool useSqlite;

        public NorthwindContext GetDbContext()
        {
            var builder = new DbContextOptionsBuilder<NorthwindContext>();
            if (useSqlite)
            {
                // Use Sqlite DB.
                builder.UseSqlite("DataSource=:memory:", x => { });
            }
            else
            {
                // Use In-Memory DB.
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).ConfigureWarnings(w =>
                {
                    w.Ignore(InMemoryEventId.TransactionIgnoredWarning);
                });
            }

            var dbContext = new NorthwindContext(builder.Options);
            if (useSqlite)
            {
                // SQLite needs to open connection to the DB.
                // Not required for in-memory-database and MS SQL.
                dbContext.Database.OpenConnection();
            }

            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        public void UseSqlite()
        {
            useSqlite = true;
        }
    }
}
