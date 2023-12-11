using SpotiLogLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotiBackEnd.DbContext
{
    internal class GenericDbContext<T, TResponse> : DbContext
        where T : class, new()
        where TResponse : class,new()
    {
        public List<TResponse> Data { get; set; }

        public GenericDbContext(string path) : base(path)
        {
            Logger logger = Logger.Instance;
            var dataFromCsv = ReadDataFromCsv<T>(path + typeof(T).Name.ToString() + ".csv", logger);

            Data = dataFromCsv.Select(o => (TResponse)Activator.CreateInstance(typeof(TResponse), o)).Cast<TResponse>().ToList();
        }
    }

}
