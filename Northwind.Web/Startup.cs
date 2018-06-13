using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NJsonSchema;
using Northwind.Web.Infrastructure;
using NSwag.AspNetCore;
using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Northwind.Application.Customers.Models;
using Northwind.Application.Infrastructure;
using Northwind.Application.Products.Queries;
using Northwind.Persistence;
using Northwind.Web.Filters;

namespace Northwind.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            // Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddMediatR(typeof(GetProductQueryHandler).GetTypeInfo().Assembly);
            // Add DbContext using SQL Server Provider
            services.AddDbContext<NorthwindDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("NorthwindDatabase")));
            // Add Open API support (will generate specification document)
            services.AddSwagger();
            // Add Logging + Seq
            services.AddLogging(loggingBuilder => { loggingBuilder.AddSeq(); });
            // Mvc + Custom Excception Filter
            services
                .AddMvc(options =>
                {
                    options.Filters.Add(typeof(CustomExceptionFilterAttribute));
                })
                .AddFluentValidation(fv => 
                    fv.RegisterValidatorsFromAssemblyContaining<CustomerDetailModel>());
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, NorthwindDbContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            app.UseSwaggerUi3(typeof(Startup).GetTypeInfo().Assembly, s =>
            {
                s.GeneratorSettings.Title = "Northwind Traders API";
                s.GeneratorSettings.DefaultUrlTemplate = "{controller}/{action}/{id?}";
                s.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
            });

            app.UseMvc();

            NorthwindInitializer.Initialize(context);
        }
    }
}
