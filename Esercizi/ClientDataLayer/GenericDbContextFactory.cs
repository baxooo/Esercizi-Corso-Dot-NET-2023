using ClientDataLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataLayer
{
    public class GenericDbContextFactory

    {
        public static IDbContext<T, TResponse> GetContext<T, TResponse>(IConfiguration conf)
            where T : class, new()
            where TResponse : class, new()
        {
            return new GenericDbContext<T, TResponse>(conf);
        }
    }
}
