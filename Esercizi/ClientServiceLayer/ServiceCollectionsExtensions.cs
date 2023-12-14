using ClientDataLayer;
using ClientDataLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServiceLayer
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection RegisterDbServices<T,TResult>(this IServiceCollection services, IConfiguration configuration)
            where T : class,new()
            where TResult : class,new()
        {
            IDbContext<T, TResult> dbContext = GenericDbContextFactory.GetContext<T,TResult>(configuration);

            services.AddTransient(typeof(IDbContext<T,TResult>), dbContext.GetType());
            return services;
        }
    }
}
