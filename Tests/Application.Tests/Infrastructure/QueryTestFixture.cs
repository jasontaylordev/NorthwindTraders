using System;
using AutoMapper;
using Northwind.Application.Infrastructure.Mappings;
using Northwind.Persistence;
using Xunit;

namespace Northwind.Application.Tests.Infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public NorthwindDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = NorthwindContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            NorthwindContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}