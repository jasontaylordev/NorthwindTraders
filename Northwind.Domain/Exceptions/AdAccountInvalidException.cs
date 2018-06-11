using System;

namespace Northwind.Domain.Exceptions
{
    public class AdAccountInvalidException : Exception
    {
        public AdAccountInvalidException(string adAccount)
            : base($"AD Account \"{adAccount}\" is invalid.")
        {
        }
    }
}
