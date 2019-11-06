using System.Collections.Generic;
using Dms.Application.Products.Queries.GetProductsFile;

namespace Dms.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records);
    }
}
