using SpotiBackEnd.Interfaces;
using SpotiBackEnd.M;
using SpotiBackEnd.Models.MediaModels;
using SpotiBackEnd.Models.UserModels;
using SpotiLogLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackEnd.DbContext
{
    internal class GenericDbContext<T, Rs> : DbContext
        where T : class, new()
        where Rs : IRating
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
