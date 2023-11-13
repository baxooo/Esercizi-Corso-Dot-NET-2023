using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal abstract class EntePubblico
    {
        protected string _nome;
        protected EntePubblico(string Nome) 
        {
            _nome = Nome;
        } 
    }
}
