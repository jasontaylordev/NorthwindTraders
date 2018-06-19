using System.Collections.Generic;
using MediatR;
using Northwind.Application.Categories.Models;

namespace Northwind.Application.Categories.Queries
{
    public class GetCategoryPreviewQuery : IRequest<List<CategoryPreviewDto>>
    {
        public int CategoryId { get; set; }
    }
}
