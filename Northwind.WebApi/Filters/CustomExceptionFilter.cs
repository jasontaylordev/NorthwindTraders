using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Northwind.Application.Exceptions;

namespace Northwind.WebApi.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var code = HttpStatusCode.InternalServerError;

            if (context.Exception is EntityNotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }

            if (context.Exception is ValidationException)
            {
                var validationException = context.Exception as ValidationException;
                code = HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)code;

                var keys = validationException.Errors.Select(e => e.PropertyName).Distinct();
                var errors = new Dictionary<string, string[]>();

                foreach (var key in keys)
                {
                    errors.Add(key, validationException.Errors.Where(e => e.PropertyName == key).Select(e => e.ErrorMessage).ToArray());
                }

                context.Result = new JsonResult(errors);

                return;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new
            {
                error = new[] { context.Exception.Message },
                stackTrace = context.Exception.StackTrace
            });
        }
    }
}
