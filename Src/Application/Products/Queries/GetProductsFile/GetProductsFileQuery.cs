using MediatR;

namespace Northwind.Application.Products.Queries.GetProductsFile
{
    public class GetProductsFileQuery : IRequest<ProductsFileVm>
    {
    }
}
