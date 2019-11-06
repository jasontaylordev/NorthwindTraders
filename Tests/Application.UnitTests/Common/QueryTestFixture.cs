using System;
using AutoMapper;
using Dms.Application.Common.Mappings;
using Dms.Persistence;
using Xunit;

namespace Dms.Application.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public DmsDbContext Context { get; private set; }
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