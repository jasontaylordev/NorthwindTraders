using System;
using Microsoft.EntityFrameworkCore;
using Dms.Domain.Entities;
using Dms.Persistence;

namespace Dms.Application.UnitTests.Common
{
    public class NorthwindContextFactory
    {
        public static DmsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<DmsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new DmsDbContext(options);

            context.Database.EnsureCreated();

            context.Customers.AddRange(new[] {
                new Customer { CustomerId = "ADAM", ContactName = "Adam Cogan" },
                new Customer { CustomerId = "JASON", ContactName = "Jason Taylor" },
                new Customer { CustomerId = "BREND", ContactName = "Brendan Richards" },
            });

            context.Orders.Add(new Order
            {
                CustomerId = "BREND"
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(DmsDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}