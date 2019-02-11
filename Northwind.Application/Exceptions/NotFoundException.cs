using System;
using System.Net;
using Northwind.Application.Exceptions.Abstractions;
using Northwind.Application.Exceptions.Models;

namespace Northwind.Application.Exceptions
{
    public class NotFoundException : BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public NotFoundException(string name, object key)
        {
            ErrorDetails = new ErrorDto
            {
                Description = $"Entity \"{name}\" ({key}) was not found."
            };
        }
    }
}