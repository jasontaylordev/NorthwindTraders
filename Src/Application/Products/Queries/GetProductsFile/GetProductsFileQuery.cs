using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Northwind.Application.Products.Queries.GetProductsFile
{
    public class GetProductsFileQuery : IRequest<ProductsFileVm>
    {
    }
}
