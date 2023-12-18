using System;
using ClientServiceLayer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ClientServiceLayer.Interfaces;
using ClientServiceLayer.Models;
using ClientServiceLayer.Models.ResponseDTO;
using ClientServiceLayer;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var conf = new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables()
                            .Build();

            IHost host;
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File(conf.GetConnectionString("DefaultConnection"))
                    .ReadFrom
                    .Configuration(conf)
                    .CreateLogger();

                host = CreateHostBuilder(args, conf).Build();
            }
            catch (Exception ex)
            {
                throw;
            }
            

            var orderService = host.Services.GetRequiredService<OrderService>();
            

            OrderModel order = new OrderModel()
            {
                Id = 1,
                Ammount = 23,
                CustomerMail = "gigiPasticci@mail.com",
                CustomerPhone = "3332333333",
                ProductsId = "1|2"

            };

            orderService.SaveNewOrder(order);

        }

        private static IHostBuilder CreateHostBuilder(string[] args, IConfigurationRoot conf)
        {
            var mailConf = new MailConf();
            conf.GetSection("EmailConfiguration").Bind(mailConf);

            return Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureServices(services =>
                {
                    services.AddTransient<INotifier, MailNotificationClient>();
                    services.AddSingleton<IConfiguration>(conf);
                    services.AddTransient<INotifier, MailNotificationClient>();
                    services.AddTransient<IMailTemplate, MailTemplate>();
                    services.AddTransient<INotificationService, MailNotificationService>();
                    services.RegisterDbServices<OrderModel, OrderModelResDTO>();
                    services.Configure<MailConf>(op =>
                    {
                        op.Host = mailConf.Host;
                        op.Port = mailConf.Port;
                        op.Username = mailConf.Username;
                        op.Password = mailConf.Password;
                        op.Security = mailConf.Security;
                    });
                });
        }
    }
}
