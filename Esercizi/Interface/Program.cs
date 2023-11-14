using System;
using Interface.NewFolder;
using Interface.StateModels;

namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            State stato1 = new EuroONUState("Italia", 1440,"Euro",GovernmentType.Republica);
            State stato2 = new EurozoneState("San Marino", 1, "Euro", false,GovernmentType.Republica);
            State stato3 = new ONUState("Marocco", 142, "Dirham", true, GovernmentType.MonarchiaCostituzionale);
            State stato4 = new State("Città del Vaticano", 0, "Euro", false,GovernmentType.MonarchiaAssoluta,23,55);

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

        private void Association()
        {
            Citizen carlo = new Citizen("Carlo", "Rossi", "20/04/2001");
            Citizen luca = new Citizen("Luca", "Bianchi", "14/10/ 1993");
            Citizen maria = new Citizen("Maria", "Proietti", "11/09/1963");
            Citizen giovanna = new Citizen("Giovanna", "Rossi", "28/01/2005");
            Citizen franco = new Citizen("Franco", "Grassi", "08/08/1989");
            Citizen antonietta = new Citizen("Antonietta", "Ferri", "01/12/1992");

            City roma = new City("Roma", "21/04/753",9,9);
            City milano = new City("Milano", "400 a.c.");
            City verona = new City("Verona", "49 a.c.");

            Comune comuneDiRoma = new Comune(roma,9,9);
            Comune comuneDiMilano = new Comune(milano,1,1);
            Comune comuneDiVerona = new Comune(verona,1,4);

            Region Lazio = new Region("Lazio", 10, 10);
            Region Lombardia = new Region("Lombardia", 0, 0);
            Region Veneto = new Region("veneto",0,5);

            Provincia provinciaDiRoma = new(roma.Name, Lazio,9,9);
            Provincia provinciaDiMilano = new Provincia(milano.Name, Lombardia,1,1);
            Provincia provinciaDiVerona = new Provincia(verona.Name, Veneto,1,4);

            State italia = new EuroONUState("Italia", 1400, "Euro", GovernmentType.Republica);

            italia.AddRegion(Lazio);
            italia.AddRegion(Veneto);
            italia.AddRegion(Lombardia);
        }
    }
}
