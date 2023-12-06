using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackEnd.Interfaces
{
    internal interface IUserRepository<T, Rs, Rq>
    {
        public Rs GetUser (string username,string password);
    }
}
