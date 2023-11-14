using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.StateModels
{
    internal class EuroONUState : EuropeanUnionState, IONU
    {
        public EuroONUState(string name, int pil, string currency, GovernmentType government, bool usesDeathPunishment = false) 
            : base(name, pil, currency,government,usesDeathPunishment)
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
