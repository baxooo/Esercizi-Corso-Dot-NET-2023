using System;
using System.Threading.Channels;

namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Nazione italy = new Nazione();
            italy.Name = "Italia";
            
            Nazione france = new Nazione();
            france.Name = "France";
            
            Nazione Germany = new Nazione();
            Germany.Name = "Germany";

            Europa eu = new Europa();

            eu.AddNation(italy);
            eu.AddNation(france);
            eu.AddNation(Germany);

            italy.Positives = 65;
            france.Positives = 45;
            Germany.Positives = 75;

            Console.WriteLine("total EU positives: " + eu.AllPositives);

            italy.Positives -= 18;

            Console.WriteLine("total EU positives: " + eu.AllPositives);

            Germany.Positives -= 21 ;

            Console.WriteLine("total EU positives: " + eu.AllPositives);

        }
    }
}
