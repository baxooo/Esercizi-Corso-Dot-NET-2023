using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.NewFolder
{
    public class City :AreaGeografica
    {
        private string _name;
        private string _annoDiFondazione;
        public string Name { get { return _name; } }
        public string AnnoDiFondazione { get { return _annoDiFondazione; } }

        public City(string name, string annoDiIstituzione, int positionX, int positionY) 
            : base(positionX,positionY)
        {
            _name = name;
            _annoDiFondazione = annoDiIstituzione;
        }
    }
}
