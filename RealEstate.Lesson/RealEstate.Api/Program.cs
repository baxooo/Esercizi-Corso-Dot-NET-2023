using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RealEstate.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scoped = host.Services.CreateScope())
            {
                var services = scoped.ServiceProvider;
                var context = services.GetService<RealEstateContext>();
                using (var db = context)
                {
                    foreach (var item in db.Users)
                    {
                        Console.WriteLine($"Name: {item.Name}");
                        Console.WriteLine($"Email: {item.Email}");
                        Console.WriteLine($"Role: {item.Role}");
                    }
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
