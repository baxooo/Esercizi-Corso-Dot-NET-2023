using System;
using Interface.StateModels;

namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            State stato1 = new EuroONUState("Italia", 1440,"Euro");
            State stato2 = new EurozoneState("San Marino", 1, "Euro", false);
            State stato3 = new ONUState("Marocco", 142, "Dirham", true);
            State stato4 = new State("Città del Vaticano", 0, "Euro", false);

            EuroCentralBank bank = new EuroCentralBank();
            CorteEuropeaDeiDirittiUmani corte = new();


            bank.CalcSpread(stato1);
            corte.RispettaIDirittiUmani(stato1);
            Console.WriteLine();

            bank.CalcSpread(stato2);
            corte.RispettaIDirittiUmani(stato2);
            Console.WriteLine();

            bank.CalcSpread(stato3);
            corte.RispettaIDirittiUmani(stato3);
            Console.WriteLine();

            bank.CalcSpread(stato4);
            corte.RispettaIDirittiUmani(stato4);
            Console.Read();
        }
    }
}
