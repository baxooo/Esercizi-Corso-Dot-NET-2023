using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.StateModels
{
    internal class ONUState : State, IONU
    {
        public ONUState(string name, int pil, string currency,bool usesDeathPunishment) 
            : base(name, pil, currency,usesDeathPunishment)
        {
        }

        public void PopulationControl()
        {
            Console.WriteLine($"{_name} controlla la nazione");
        }

        public void TerritoryDefence()
        {
            Console.WriteLine($"{_name} difende i propri confini");
        }
    }
}
