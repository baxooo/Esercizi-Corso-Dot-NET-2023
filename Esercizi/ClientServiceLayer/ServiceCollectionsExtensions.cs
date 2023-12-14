using ClientDataLayer;
using ClientServiceLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClientServiceLayer
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection RegisterDbServices<T,TResponse>(this IServiceCollection services)
            where T : class, new()
            where TResponse : class, new()
        {
            services.AddDataLayerServices<T, TResponse>();
            services.AddTransient<OrderService>();
            return services;
        }
    }
}
