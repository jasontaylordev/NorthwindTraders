using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Northwind.Application.Common.Interfaces;
using Northwind.Application.Products.Queries.GetProductsFile;

namespace Northwind.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                var config = new CsvConfiguration(CultureInfo.CurrentCulture);                
                using (var csvWriter = new CsvWriter(streamWriter, config))
                {
                    csvWriter.Context.RegisterClassMap<ProductFileRecordMap>();
                    csvWriter.WriteRecords(records);
                }
            }

            return memoryStream.ToArray();
        }
    }
}
