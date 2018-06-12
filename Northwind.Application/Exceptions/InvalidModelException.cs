using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
