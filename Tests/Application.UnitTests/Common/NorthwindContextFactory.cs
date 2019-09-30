using System;
using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.UnitTests.Common
{
    public class NorthwindContextFactory
    {
        public static NorthwindDbContext Create()
        {
            var options = new DbContextOptionsBuilder<NorthwindDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new NorthwindDbContext(options);

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

        public static void Destroy(NorthwindDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}