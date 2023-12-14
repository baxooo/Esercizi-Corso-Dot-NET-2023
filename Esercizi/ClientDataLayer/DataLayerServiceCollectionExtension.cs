using ClientDataLayer.Interfaces;
using ClientDataLayer.Models;
using ClientDataLayer.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataLayer
{
    public  static class DataLayerServiceCollectionExtension
    {
        public static IServiceCollection AddDataLayerServices<T,TResponse>(this IServiceCollection services)
            where T : class,new()
            where TResponse : class,new()
        {
            services.AddTransient<IDbContext<T,TResponse>, GenericDbContext<T,TResponse>>();
            services.AddTransient<IOrderRepository<T,TResponse>,OrderRepository<T,TResponse>>();

            return services;
        }
    }
}
