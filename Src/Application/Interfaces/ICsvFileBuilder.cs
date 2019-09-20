using System.Collections.Generic;
using Northwind.Application.Products.Queries.GetProductsFile;

namespace Northwind.Application.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductsFile(IEnumerable<ProductFileRecord> records);
    }
}
