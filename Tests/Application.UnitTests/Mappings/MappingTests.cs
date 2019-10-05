using AutoMapper;
using Northwind.Application.Categories.Queries.GetCategoriesList;
using Northwind.Application.Customers.Queries.GetCustomerDetail;
using Northwind.Application.Customers.Queries.GetCustomersList;
using Northwind.Application.Employees.Queries.GetEmployeeDetail;
using Northwind.Application.Employees.Queries.GetEmployeesList;
using Northwind.Application.Products.Queries.GetProductDetail;
using Northwind.Application.Products.Queries.GetProductsFile;
using Northwind.Application.Products.Queries.GetProductsList;
using Northwind.Domain.Entities;
using Shouldly;
using Xunit;

namespace Northwind.Application.UnitTests.Mappings
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
        public void ShouldMapCategoryToCategoryDto()
        {
            var entity = new Category();

            var result = _mapper.Map<CategoryDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<CategoryDto>();
        }

        [Fact]
        public void ShouldMapCustomerToCustomerLookupDto()
        {
            var entity = new Customer();

            var result = _mapper.Map<CustomerLookupDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<CustomerLookupDto>();
        }

        [Fact]
        public void ShouldMapProductToProductDetailVm()
        {
            var entity = new Product();

            var result = _mapper.Map<ProductDetailVm>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<ProductDetailVm>();
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
        public void ShouldMapProductToProductRecordDto()
        {
            var entity = new Product();

            var result = _mapper.Map<ProductRecordDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<ProductRecordDto>();
        }

        [Fact]
        public void ShouldMapCustomerToCustomerDetailVm()
        {
            var entity = new Customer();

            var result = _mapper.Map<CustomerDetailVm>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<CustomerDetailVm>();
        }

        [Fact]
        public void ShouldMapEmployeeToEmployeeLookupDto()
        {
            var entity = new Employee();

            var result = _mapper.Map<EmployeeLookupDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<EmployeeLookupDto>();
        }

        [Fact]
        public void ShouldMapEmployeeTerritoryToEmployeeTerritoryDto()
        {
            var entity = new EmployeeTerritory();

            var result = _mapper.Map<EmployeeTerritoryDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<EmployeeTerritoryDto>();
        }
    }
}
