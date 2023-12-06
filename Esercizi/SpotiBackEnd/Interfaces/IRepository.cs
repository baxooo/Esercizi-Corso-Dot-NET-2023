using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackEnd.Interfaces
{
    internal interface IRepository<T,Rs>
    {
        public List<Rs> GetAll();
        public Rs GetById(int id);
        public bool DeleteById(int id);
        public bool Update(T media);  
    }
}
