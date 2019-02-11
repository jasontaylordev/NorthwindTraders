using System;
using System.Collections.Generic;
using System.Net;
using Northwind.Application.Exceptions.Abstractions;
using Northwind.Application.Exceptions.Models;

namespace Northwind.Application.Exceptions
{
    public class DeleteFailureException : BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public DeleteFailureException(string name, object key, string description)
        {
            ErrorDetails = new ErrorDto
            {
                Description = $"Deletion of entity \"{name}\" ({key}) failed. {description}"
            };
        }
    }
}
