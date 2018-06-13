using MediatR;

namespace Northwind.Application.Products.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public DeleteProductCommand()
        {
        }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
