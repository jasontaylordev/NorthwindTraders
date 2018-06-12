using MediatR;
using Northwind.Application.Categories.Models;

namespace Northwind.Application.Categories.Queries
{
    public class GetCategoryPreviewQuery : IRequest<CategoryPreviewDto>
    {
        public int CategoryId { get; set; }
    }
}
