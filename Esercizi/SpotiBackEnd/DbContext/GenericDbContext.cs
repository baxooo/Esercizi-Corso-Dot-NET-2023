using SpotiLogLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotiBackEnd.DbContext
{
    internal class GenericDbContext<T, Rs> : DbContext
        where T : class, new()
        where Rs : class,new()
    {
        public List<Rs> Data { get; set; }

        public GenericDbContext(string path) : base(path)
        {
            Logger logger = Logger.Instance;
            var dataFromCsv = ReadDataFromCsv<T>(path + typeof(T).Name.ToString() + ".csv", logger);

            Data = dataFromCsv.Select(o => Activator.CreateInstance(typeof(Rs), o)).Cast<Rs>().ToList();
        }
    }

}
