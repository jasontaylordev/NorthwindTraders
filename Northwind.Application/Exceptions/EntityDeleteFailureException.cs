using System;

namespace Northwind.Application.Exceptions
{
    public class EntityDeleteFailureException : Exception
    {
        public EntityDeleteFailureException(string name, object key, string message)
            : base($"Deletion of entity \"{name}\" ({key}) failed. {message}")
        {
        }
    }
}
