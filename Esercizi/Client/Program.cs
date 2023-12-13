using System;
using ClientDataLayer.Repositories;
using ClientDataLayer.Interfaces;
using ClientServiceLayer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ClientServiceLayer.Interfaces;
using ClientDataLayer.Models;
using ClientServiceLayer.Models;
using ClientServiceLayer.Models.ResponseDTO;

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

            var mailConf = new MailConf();
            conf.GetSection("EmailConfiguration").Bind(mailConf);


            var services = new ServiceCollection()
                            .Configure<MailConf>(op =>
                            {
                                op.Host = mailConf.Host;
                                op.Port = mailConf.Port;
                                op.Username = mailConf.Username;
                                op.Password = mailConf.Password;
                                op.Security = mailConf.Security;
                            });

            /* registra l'oggetto IConfiguration nel container DI come singleton.
            *  Questo significa che una singola istanza di IConfiguration verrà condivisa
            * in tutta l'applicazione. 
            */
            services.AddSingleton<IConfiguration>(conf);
            /* questa linea di codice fa in modo di passare la configurazione che abbiamo creato
             * con il ConfigurationBuilder ad un eventuale classe che ne necessita, in questo
             * modo per esempio possiamo avere accesso ai dati del json che in questo caso contengono
             * il path per i file .csv
            */


            /* La scelta di AddTransient implica una nuova istanza ad ogni richiesta.
             * Assicurati che questo comportamento sia adatto per il tuo EmailSender. 
             * Se, per esempio, EmailSender mantenesse stato o risorse (come una connessione di rete),
             * potresti voler considerare AddSingleton  
            */ 
            services.AddTransient<INotifier, MailNotificationClient>();
            services.AddSingleton<IOrderRepository<OrderModel, OrderModelResDTO>, 
                OrderRepository<OrderModel, OrderModelResDTO>>();
            services.AddTransient<IMailTemplate, MailTemplate>();
            services.AddTransient<INotificationService, MailNotificationService>();
            services.AddTransient<OrderService>();


            var serviceProvider = services.BuildServiceProvider();

            var orderService = serviceProvider.GetRequiredService<OrderService>();
            

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
    }
}
