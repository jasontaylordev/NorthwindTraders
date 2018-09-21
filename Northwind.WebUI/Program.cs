using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Northwind.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace Northwind.WebUI
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = CreateWebHostBuilder(args).Build();

      // migrate the database.  Best practice = in Main, using service scope
      using (var scope = host.Services.CreateScope())
      {
        try
        {
          var context = scope.ServiceProvider.GetService<NorthwindDbContext>();
          context.Database.Migrate();
        }
        catch (Exception ex)
        {
          var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
          logger.LogError(ex, "An error occurred while migrating the database.");
        }
      }

      // run the web app
      host.Run();
    }
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
  }
}
