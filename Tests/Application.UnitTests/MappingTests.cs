using AutoMapper;
using Northwind.Application.Categories.Queries.GetCategoriesList;
using Northwind.Application.Customers.Queries.GetCustomerDetail;
using Northwind.Application.Customers.Queries.GetCustomersList;
using Northwind.Application.Products.Queries.GetProductsList;
using Northwind.Application.Products.Queries.GetProduct;
using Northwind.Application.Products.Queries.GetProductsFile;
using Northwind.Domain.Entities;
using Shouldly;
using Xunit;

namespace Northwind.Application.UnitTests
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

            var result = _mapper.Map<CategoryLookup>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<CategoryLookup>();
        }

        [Fact]
        public void ShouldMapCustomerToCustomerLookupModel()
        {
            var entity = new Customer();

            var result = _mapper.Map<CustomerLookup>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<CustomerLookup>();
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

        [Fact]
        public void ShouldMapCustomerToCustomerDetailVm()
        {
            var entity = new Customer();

            var result = _mapper.Map<CustomerDetailVm>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<CustomerDetailVm>();
        }
    }
}
