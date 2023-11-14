using System;
using Interface.NewFolder;
using Interface.StateModels;

namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            State stato1 = new EuroONUState("Italia", 1440,"Euro");
            State stato2 = new EurozoneState("San Marino", 1, "Euro", false,GovernmentType.Republica);
            State stato3 = new ONUState("Marocco", 142, "Dirham", true, GovernmentType.MonarchiaCostituzionale);
            State stato4 = new State("Città del Vaticano", 0, "Euro", false,GovernmentType.MonarchiaAssoluta);

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

            City roma = new City("Roma", "21/04/753");
            City milano = new City("Milano", "400 a.c.");
            City verona = new City("Verona", "49 a.c.");

            Comune comuneDiRoma = new Comune(roma);
            Comune comuneDiMilano = new Comune(milano);
            Comune comuneDiVerona = new Comune(verona);

            Region Lazio = new Region("Lazio");
            Region Lombardia = new Region("Lombardia");
            Region Veneto = new Region("veneto");

            Provincia provinciaDiRoma = new(roma.Name, Lazio);
            Provincia provinciaDiMilano = new Provincia(milano.Name, Lombardia);
            Provincia provinciaDiVerona = new Provincia(verona.Name, Veneto);

            State italia = new EuroONUState("Italia", 1400, "Euro");

            italia.AddRegion(Lazio);
            italia.AddRegion(Veneto);
            italia.AddRegion(Lombardia);
        }
    }
}
