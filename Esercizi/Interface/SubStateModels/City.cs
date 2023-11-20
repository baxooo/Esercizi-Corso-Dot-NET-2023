using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.SubStateModels
{
    internal class City :AreaGeografica
    {
        protected string _name;
        public string Name { get { return _name; } }

        public Country Country { get; set; }

        public City(string name,  int positionX, int positionY) 
            : base(positionX,positionY)
        {
            _name = name;
            Country = new Country(name);
        }
    }
}
