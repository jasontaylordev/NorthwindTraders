using System;

namespace Northwind.Application.Exceptions
{
    public class InvalidModelException : Exception
    {
        public InvalidModelException(string name)
            : base($"Nodel \"{name}\" is invalid.")
        {
        }
    }
}
