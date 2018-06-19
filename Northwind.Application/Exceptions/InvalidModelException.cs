using System;

namespace Northwind.Application.Exceptions
{
    public class InvalidModelException : Exception
    {
        public InvalidModelException(string name)
            : base($"Model \"{name}\" is invalid.")
        {
        }
    }
}
