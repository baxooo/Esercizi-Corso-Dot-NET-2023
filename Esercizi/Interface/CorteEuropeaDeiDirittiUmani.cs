using Interface.StateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal class CorteEuropeaDeiDirittiUmani
    {
        public void RispettaIDirittiUmani(State state)
        {
            string fraseParteUno = "Questo stato ";
            string fraseParteDue = "rispetta i diritti umani";

            Random rnd = new Random();

            int n = rnd.Next(100);

            if(n % 2 == 0)
                Console.WriteLine(fraseParteUno + fraseParteDue);
            else Console.WriteLine(fraseParteUno + "non " + fraseParteDue);


        }
    }
}
