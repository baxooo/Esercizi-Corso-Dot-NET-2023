using System;
using Interface.SubStateModels;
using Interface.StateModels;
using Interface.EU;
using Interface.OrganizationModels;

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

            CambiaRegione();

            Console.Read();
        }

        private static void Association()
        {
            ComuneEU comuneDiRoma = new ComuneEU("Roma", 9,9);

            CitizenEU carlo = new CitizenEU("Carlo", "Rossi", "20/04/2001",comuneDiRoma);

            RegionEU Lazio = new RegionEU("Lazio", 10, 10);

            ProvinciaEU provinciaDiRoma = new(comuneDiRoma.Name, Lazio,9,9);

            State italia = new EuroONUState("Italia", 1400, "Euro", GovernmentType.Republica, 33, 57, "Esercito Della Republica Italiana", "Svizzera");

            italia.AddRegion(Lazio);
        }

        private static void CambiaRegione()
        {
            EuropeanUnionState italia = new ("Italia", 1400, "Euro", GovernmentType.Republica, 33, 57, "Esercito Della Republica Italiana", "Austria");
            EuropeanUnionState austria = new ("Austria", 480, "Euro", GovernmentType.Republica, 33, 57, "Austrian Armed Forces", "Italia");
            EuParliament par = new EuParliament();

            italia.CreateRegion("Trentino Alto Adige", 3, 4);

            EuParliament.MoveRegionToOtherCountryRequest(italia, austria, italia.Region);
        }

    }
}
