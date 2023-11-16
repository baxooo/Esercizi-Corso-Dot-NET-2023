using Interface.Interfaces;
using Interface.StateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.EU
{
    internal class StrasbourgCourt
    {
        public void RispettaIDirittiUmani(State state)
        {

            string fraseParteUno = "Questo stato ";
            string fraseParteDue = "rispetta i diritti umani";

            if (state is IONU)
                Console.WriteLine(fraseParteUno + fraseParteDue);
            else Console.WriteLine(fraseParteUno + "non " + fraseParteDue);
        }
    }
}
