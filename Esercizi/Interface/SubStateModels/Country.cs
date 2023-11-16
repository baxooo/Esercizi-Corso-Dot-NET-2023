using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.SubStateModels
{
    public class Country
    {
        private string _name;
        public string Name { get { return _name; } }
        public Country(string name)
        {
              _name = name;
        }
    }
}
