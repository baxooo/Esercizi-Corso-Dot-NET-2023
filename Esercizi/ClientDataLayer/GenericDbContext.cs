using ClientDataLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataLayer
{
    internal class GenericDbContext<T, TResponse> : DbContext, IDbContext<T, TResponse>
        where T : class, new()
        where TResponse : class, new()
    {
        public List<TResponse> Data { get; set; }

        public GenericDbContext(IConfiguration config,ILogger<GenericDbContext<T,TResponse>> logger) : base(config)
        {
            _logger = logger;
            var dataFromCsv = ReadDataFromCsv<T>(config.GetConnectionString("DefaultConnection") + typeof(T).Name.ToString() + ".csv");

            Data = dataFromCsv.Select(o => Activator.CreateInstance(typeof(TResponse), o)).Cast<TResponse>().ToList();
        }
    }
}
