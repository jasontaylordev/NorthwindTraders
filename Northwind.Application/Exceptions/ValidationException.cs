using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FluentValidation.Results;
using Northwind.Application.Exceptions.Abstractions;
using Northwind.Application.Exceptions.Models;

namespace Northwind.Application.Exceptions
{
    public class ValidationException : BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public ValidationException()
        {
            ErrorDetails = new ErrorDto
            {
                Description = "One or more validation failures have occurred."
            };
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();
                ErrorDetails.Failures.Add(propertyName, propertyFailures);
            }
        }
    }
}
