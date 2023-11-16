using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface.StateModels;

namespace Interface.EU
{
    internal class EuroCentralBank
    {
        public EuroCentralBank()
        {

        }

        public void CalcSpread(State state)
        {
            Random rnd = new Random();
            Console.WriteLine($"Lo spread dello stato {state.Name} è di {(rnd.NextDouble() * 12 - 3).ToString("0.000")}% ");
        }
    }
}
