using System.Collections.Generic;
using Northwind.Application.Products.Queries.GetProductsFile;

namespace Northwind.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records);
    }
}
