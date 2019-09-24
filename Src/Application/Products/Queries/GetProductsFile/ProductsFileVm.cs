namespace Northwind.Application.Products.Queries.GetProductsFile
{
    public class ProductsFileVm
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
