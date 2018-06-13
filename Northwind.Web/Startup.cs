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
using MediatR;
using MediatR.Pipeline;
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
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddMediatR(typeof(GetProductQuery).GetTypeInfo().Assembly);
            services.AddDbContext<NorthwindDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("NorthwindDatabase")));
            services.AddSwagger();
            services.AddLogging(loggingBuilder => { loggingBuilder.AddSeq(); });
            services.AddMvc(options => { options.Filters.Add(typeof(CustomExceptionFilterAttribute)); });
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
