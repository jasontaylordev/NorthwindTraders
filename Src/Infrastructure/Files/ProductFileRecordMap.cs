using CsvHelper.Configuration;
using Northwind.Application.Products.Queries.GetProductsFile;

namespace Northwind.Infrastructure.Files
{
    public sealed class ProductFileRecordMap : ClassMap<ProductRecordDto>
    {
        public ProductFileRecordMap()
        {
            AutoMap(System.Globalization.CultureInfo.InvariantCulture);
            Map(m => m.UnitPrice).Name("Unit Price").Convert(c => string.Format("C", c.Value.UnitPrice ?? 0));
        }
    }
}
