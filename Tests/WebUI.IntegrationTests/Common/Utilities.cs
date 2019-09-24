using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.WebUI.IntegrationTests.Common
{
    public class Utilities
    {
        public static StringContent GetRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }

        public static void InitializeDbForTests(NorthwindDbContext context)
        {
            context.Customers.Add(new Customer
            {
                CustomerId = "ALFKI",
                Address = "Obere Str. 57",
                City = "Berlin",
                CompanyName = "Alfreds Futterkiste",
                ContactName = "Maria Anders",
                ContactTitle = "Sales Representative",
                Country = "Germany",
                Fax = "030-0076545",
                Phone = "030-0074321",
                PostalCode = "12209"
            });

            var supplier1 = new Supplier
            {
                CompanyName = "Exotic Liquids",
                ContactName = "Charlotte Cooper",
                ContactTitle = "Purchasing Manager",
                Address = "49 Gilbert St.",
                City = "London",
                PostalCode = "EC1 4SD",
                Fax = "",
                Phone = "(171) 555-2222",
                HomePage = ""
            };

            context.Suppliers.Add(supplier1);

            var category1 = new Category
            {
                CategoryName = "Beverages",
                Description = "Soft drinks, coffees, teas, beers, and ales"
            };

            context.Categories.Add(category1);

            context.Products.Add(
                new Product
                {
                    ProductName = "Chai",
                    Supplier = supplier1,
                    Category = category1,
                    QuantityPerUnit = "10 boxes x 20 bags",
                    UnitPrice = 18.00m,
                    UnitsInStock = 39,
                    UnitsOnOrder = 0,
                    ReorderLevel = 10,
                    Discontinued = false
                });

            context.SaveChanges();
        }
    }
}
