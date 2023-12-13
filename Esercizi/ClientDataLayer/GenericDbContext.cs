using Microsoft.Extensions.Configuration;
using SpotiLogLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataLayer
{
    internal class GenericDbContext<T, TResponse> : DbContext
        where T : class, new()
        where TResponse : class, new()
    {
        public List<TResponse> Data { get; set; }

        public GenericDbContext(IConfiguration config) : base(config)
        {
            Logger logger = Logger.Instance;
            var dataFromCsv = ReadDataFromCsv<T>(config.GetConnectionString("DefaultConnection") + typeof(T).Name.ToString() + ".csv", logger);

            Data = dataFromCsv.Select(o => Activator.CreateInstance(typeof(TResponse), o)).Cast<TResponse>().ToList();
        }
    }
}
