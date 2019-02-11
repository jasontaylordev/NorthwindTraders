using Northwind.Application.Exceptions.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace Northwind.Application.Exceptions.Abstractions
{
    public abstract class BaseException : Exception
    {
        public ErrorDto ErrorDetails { get; set; }
        public abstract HttpStatusCode StatusCode { get; }
    }
}
