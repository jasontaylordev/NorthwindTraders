using CsvHelper.Configuration;
using Northwind.Application.Products.Queries.GetProductsFile;

namespace Northwind.Infrastructure.Files
{
    public sealed class ProductFileRecordMap : ClassMap<ProductRecordDto>
    {
        public ProductFileRecordMap()
        {
            AutoMap(System.Globalization.CultureInfo.CurrentCulture);
            //TODO: Technical Debt - Figure out how to map the Unit Price to a nullable decimal and return the ProductFileRecordMap. 12-09-21 Paras Parmar

            //Map<ProductFileRecordMap>(m => m.UnitPrice).Name("Unit Price").ConvertUsing(c => (c.UnitPrice ?? 0).ToString("C"));
        }
    }
}
