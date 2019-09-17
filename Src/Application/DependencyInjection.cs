using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Infrastructure;
using Northwind.Application.Infrastructure.AutoMapper;

namespace Northwind.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
