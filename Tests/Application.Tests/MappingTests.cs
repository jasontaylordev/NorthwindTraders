using AutoMapper;
using Northwind.Application.Categories.Queries.GetCategoriesList;
using Northwind.Application.Customers.Queries.GetCustomersList;
using Northwind.Application.Products.Queries.GetAllProducts;
using Northwind.Application.Products.Queries.GetProduct;
using Northwind.Application.Products.Queries.GetProductsFile;
using Northwind.Domain.Entities;
using Shouldly;
using Xunit;

namespace Northwind.Application.Tests
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void ShouldMapCategoryToCategoryLookupModel()
        {
            var entity = new Category();

            var result = _mapper.Map<CategoryLookupModel>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<CategoryLookupModel>();
        }

        [Fact]
        public void ShouldMapCustomerToCustomerLookupModel()
        {
            var entity = new Customer();

            var result = _mapper.Map<CustomerLookupModel>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<CustomerLookupModel>();
        }

        [Fact]
        public void ShouldMapProductToProductViewModel()
        {
            var entity = new Product();

            var result = _mapper.Map<ProductViewModel>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<ProductViewModel>();
        }

        [Fact]
        public void ShouldMapProductToProductDto()
        {
            var entity = new Product();

            var result = _mapper.Map<ProductDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<ProductDto>();
        }

        [Fact]
        public void ShouldMapProductToProductFileRecord()
        {
            var entity = new Product();

            var result = _mapper.Map<ProductFileRecord>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<ProductFileRecord>();
        }
    }
}
