using ClientDataLayer.Interfaces;
using ClientDataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ClientDataLayer
{
    public  static class DataLayerServiceCollectionExtension
    {
        public static IServiceCollection AddDataLayerServices<T,TResponse>(this IServiceCollection services)
            where T : class, new()
            where TResponse : class, new()
        {
            services.AddTransient<IDbContext<T,TResponse>, GenericDbContext<T,TResponse>>();
            services.AddTransient<IOrderRepository<T,TResponse>,OrderRepository<T,TResponse>>();

            return services;
        }
    }
}
