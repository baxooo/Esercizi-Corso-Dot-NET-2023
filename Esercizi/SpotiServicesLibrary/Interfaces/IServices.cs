using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServicesLibrary.Interfaces
{
    internal interface IServices<T, Rs>
    {
        public Rs Update();
        public Rs GetAll();
        public Rs GetById(int id);
        public Rs Delete(int id);
    }
}
