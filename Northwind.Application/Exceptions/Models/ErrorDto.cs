using System.Collections.Generic;

namespace Northwind.Application.Exceptions.Models
{
    public class ErrorDto
    {
        public string Description { get; set; }
        public IDictionary<string, string[]> Failures { get; private set; }

        public ErrorDto()
        {
            Failures = new Dictionary<string, string[]>();
        }
    }
}
