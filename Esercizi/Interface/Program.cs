using System;
using Interface.SubStateModels;
using Interface.StateModels;
using Interface.EU;

namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            State stato1 = new EuroONUState("Italia", 1440,"Euro",GovernmentType.Republica,33,57,"Esercito Della Republica Italiana","Svizzera");
            State stato2 = new EurozoneState("San Marino", 1, "Euro", GovernmentType.Republica, 29, 58, "Sammarinese Armed Forces", "Italy"); ;
            State stato3 = new ONUState("Marocco", 142, "Dirham", GovernmentType.MonarchiaCostituzionale,6,12,"The Royal Moroccan Army","Algeri");
            State stato4 = new State("Città del Vaticano", 0, "Euro", GovernmentType.MonarchiaAssoluta, 23, 55, "Guardie Svizzere", "Italy"); ;

            EuroCentralBank bank = new EuroCentralBank();
            StrasbourgCourt corte = new();


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

        private void Association()
        {
            ComuneEU comuneDiRoma = new ComuneEU("Roma", 9,9);

            CitizenEU carlo = new CitizenEU("Carlo", "Rossi", "20/04/2001",comuneDiRoma);

            RegionEU Lazio = new RegionEU("Lazio", 10, 10);

            ProvinciaEU provinciaDiRoma = new(comuneDiRoma.Name, Lazio,9,9);

            State italia = new EuroONUState("Italia", 1400, "Euro", GovernmentType.Republica, 33, 57,"Esercito Della Republica Italiana", "Svizzera");

            italia.AddRegion(Lazio);
        }
    }
}
