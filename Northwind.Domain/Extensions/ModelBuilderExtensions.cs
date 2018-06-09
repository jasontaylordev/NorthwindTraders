using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Domain.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
        {
            var applyConfigurationMethodInfo = modelBuilder
                .GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .First(m => m.Name.Equals("ApplyConfiguration", StringComparison.OrdinalIgnoreCase));

            typeof(NorthwindContext).Assembly
                .GetTypes()
                .Select(type => (type,
                    i: type.GetInterfaces()
                        .FirstOrDefault(i =>
                        i.Name.Equals(typeof(IEntityTypeConfiguration<>).Name, StringComparison.Ordinal))))
                .Where(it => it.i != null)
                .Select(config => (entityType: config.i.GetGenericArguments()[0], entityTypeConfiguration: Activator.CreateInstance(config.i)))
                .ToList()
                .ForEach(config =>
                    applyConfigurationMethodInfo.MakeGenericMethod(config.entityType).Invoke(modelBuilder, new[] { config.entityTypeConfiguration }));
        }
    }
}
