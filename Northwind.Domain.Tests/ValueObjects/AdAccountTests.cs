using Northwind.Domain.Exceptions;
using Northwind.Domain.ValueObjects;
using Xunit;

namespace Northwind.Domain.Tests.ValueObjects
{
    public class AdAccountTests
    {
        [Fact]
        public void ShouldHaveCorrectDomain()
        {
            var account = new AdAccount("SSW\\Jason");

            Assert.Equal("SSW", account.Domain);
        }

        [Fact]
        public void ShouldHaveCorrectName()
        {
            var account = new AdAccount("SSW\\Jason");

            Assert.Equal("Jason", account.Name);
        }

        [Fact]
        public void ToStringReturnsDomainAndName()
        {
            const string value = "SSW\\Jason";

            var account = new AdAccount(value);

            Assert.Equal(value, account.ToString());
        }

        [Fact]
        public void ImplicitConversionToStringReturnsDomainAndName()
        {
            const string value = "SSW\\Jason";

            var account = new AdAccount(value);

            string result = account;

            Assert.Equal(value, result);
        }

        [Fact]
        public void ExplicitConversionFromStringSetsDomainAndName()
        {
            var account = (AdAccount) "SSW\\Jason";

            Assert.Equal("SSW", account.Domain);
            Assert.Equal("Jason", account.Name);
        }

        [Fact]
        public void ShouldThrowAdAccountInvalidExceptionForInvalidAdAccount()
        {
            Assert.Throws<AdAccountInvalidException>(() => (AdAccount) "SSWJason");
        }
    }
}
