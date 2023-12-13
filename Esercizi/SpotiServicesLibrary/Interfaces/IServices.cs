using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServicesLibrary.Interfaces
{
    internal interface IServices<T, TResponse>
    {
        public TResponse Update();
        public TResponse GetAll();
        public TResponse GetById(int id);
        public TResponse Delete(int id);
    }
}
