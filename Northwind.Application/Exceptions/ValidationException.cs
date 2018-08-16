using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Northwind.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(List<ValidationFailure> failures)
            : base("One or more validation failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();

            var keys = failures.Select(e => e.PropertyName).Distinct();
            foreach (var key in keys)
            {
                Failures.Add(key, failures.Where(e => e.PropertyName == key).Select(e => e.ErrorMessage).ToArray());
            }
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}
