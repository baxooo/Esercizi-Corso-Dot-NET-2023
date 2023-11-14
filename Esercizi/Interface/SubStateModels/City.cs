using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.NewFolder
{
    public class City
    {
        private string _name;
        private string _annoDiFondazione;
        public string Name { get { return _name; } }
        public string AnnoDiFondazione { get { return _annoDiFondazione; } }

        public City(string name, string annoDiIstituzione)
        {
            _name = name;
            _annoDiFondazione = annoDiIstituzione;
        }
    }
}
