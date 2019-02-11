using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Northwind.Application.Exceptions.Abstractions;
using Northwind.Application.Exceptions.Models;

namespace Northwind.WebUI.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            HttpStatusCode code;
            ErrorDto error;

            if (context.Exception is BaseException exception)
            {
                code = exception.StatusCode;
                error = exception.ErrorDetails;
            }
            else
            {
                code = HttpStatusCode.InternalServerError;
                error = new ErrorDto
                {
                    Description = context.Exception.Message
                };
            }

            context.Result = new JsonResult(error);
            context.HttpContext.Response.StatusCode = (int)code;
            context.HttpContext.Response.ContentType = "application/json";
        }
    }
}
