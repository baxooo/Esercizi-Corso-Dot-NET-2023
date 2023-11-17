using System;
using System.Linq;
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
            Anagrafiche();
            Console.Read();
        }

        private static void SpreadEDirittiUmani()
        {
            State stato1 = new EuroONUState("Italia", 1440, "Euro", GovernmentType.Republica, 33, 57, "Esercito Della Republica Italiana", "Svizzera");
            State stato2 = new EurozoneState("San Marino", 1, "Euro", GovernmentType.Republica, 29, 58, "Sammarinese Armed Forces", "Italy"); ;
            State stato3 = new ONUState("Marocco", 142, "Dirham", GovernmentType.MonarchiaCostituzionale, 6, 12, "The Royal Moroccan Army", "Algeri");
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

            //EuParliament.MoveRegionToOtherCountryRequest(italia, austria, italia.Region);
        }

        private static void Anagrafiche()
        {
            RegionEU Lazio = new RegionEU("Lazio", 10, 10);
            RegionEU Umbria = new RegionEU("Umbria", 8, 10);

            var provinciaDiRoma = new ProvinciaEU("Roma", 8, 9);
            var comuniDiRoma = new ComuneEU[]
            {
                new ComuneEU("Roma", 8, 9),
                new ComuneEU("Bracciano", 8, 8),
                new ComuneEU("Colleferro", 7, 8),
                new ComuneEU("Pomezia", 11, 9),
                new ComuneEU("Anticoli Corrado", 9, 12),
                new ComuneEU("Cave", 10, 10)
            };

            var provinciaDiRieti = new ProvinciaEU("Rieti", 9, 9);
            var comuniDiRieti = new ComuneEU[]
            {
                new ComuneEU("Amatrice", 6, 11),
                new ComuneEU("Orvino", 6, 12),
                new ComuneEU("Rieti", 5, 10),
            };
            var provinciaDiViterbo = new ProvinciaEU("Viterbo", 7, 9);
            var comuniDiViterbo = new ComuneEU[]
            {
                new ComuneEU("Bassano Romano",5,3),
                new ComuneEU("Farnese",5,2),
                new ComuneEU("Viterbo",4,3)
            };
      
            var provinciaDiPerugia = new ProvinciaEU("Perugia", 7, 9);
            var comuniDiPerugia = new ComuneEU[]
            {
                new ComuneEU("Assisi",7,7),
                new ComuneEU("Norcia",7,8),
                new ComuneEU("Trevi",8,7),
                new ComuneEU("Foligno",7,9),
                new ComuneEU("Spoleto",8,10),
                new ComuneEU("Perugia",7,11)
            };
            var provinciaDiTerni = new ProvinciaEU("Terni", 7, 9);

            var comuniDiTerni = new ComuneEU[]
            {
                new ComuneEU("Allerona",7,7),
                new ComuneEU("Arrone",7,8),
                new ComuneEU("Baschi",8,7),
                new ComuneEU("Orvieto",7,9),
                new ComuneEU("Narni",8,10),
                new ComuneEU("Terni",7,11)
            };

            foreach(var comune in comuniDiRoma)
                provinciaDiRoma.AddComune(comune);
            
            foreach(var comune in comuniDiRieti)
                provinciaDiRieti.AddComune(comune);

            foreach (var comune in comuniDiViterbo)
                provinciaDiViterbo.AddComune(comune);

            foreach (var comune in comuniDiPerugia)
                provinciaDiPerugia.AddComune(comune);

            foreach (var comune in comuniDiTerni)
                provinciaDiTerni.AddComune(comune);

            Lazio.AddProvincia(provinciaDiRieti);
            Lazio.AddProvincia(provinciaDiRoma);
            Lazio.AddProvincia(provinciaDiViterbo);

            Umbria.AddProvincia(provinciaDiTerni);
            Umbria.AddProvincia(provinciaDiPerugia);

            var Italia = new EuropeanUnionState("Italia", 1400, "Euro", GovernmentType.Republica, 10, 10,
                "Esercito Della Repubblica Italiana", "Austria");
            Italia.AddRegion(Lazio);
            Italia.AddRegion(Umbria);

            var gen = new GeneratoreAnagrafiche();

            gen.SmistaPopolazione(Italia, 1000);
        }
    }
}
