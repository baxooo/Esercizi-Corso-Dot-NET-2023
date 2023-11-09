using System;
using System.Collections.Generic;
using Classes.PersonTypes;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Citizen citizen1 = new Student("Aronne", "Piperno", 21, false, false, 95, 29, 0, 737084);
            Citizen citizen2 = new Citizen("Marco", "Rossi", 24, false, false, 2, 6001000);
            Citizen citizen3 = new UniversityStudent("Giulia", "Trentini", 35, false, true, 91, 2, 7004800, 30);
            Citizen citizen4 = new Citizen("Marcello", "Martana", 71, false, false, 0, 100000001);
            Citizen citizen5 = new Military("Nico", "Giraldi", 44, false, true, 1, 9008000, 3, 283);
            Citizen citizen6 = new Citizen("Franco", "Lechner", 41, false, true, 3, 1800300);
            List<Citizen> list = new List<Citizen>();
            list.Add(citizen1);
            list.Add(citizen2);
            list.Add(citizen3);
            list.Add(citizen4);
            list.Add(citizen5);
            list.Add(citizen6);

            Comune comune = new Comune("inps","Roma",19043512);

            foreach (Citizen citizen in list)
            {
                bool elegible = comune.IsCitizenElegible(citizen);
                string applicante = $"il Citadino {citizen.Name} {citizen.LastName}";

                if (elegible)
                    Console.WriteLine(applicante +" è idoneo".PadLeft(50 - applicante.Length));
                else Console.WriteLine(applicante + " non è idoneo".PadLeft(50 - applicante.Length));            
            }
            Console.Read();
        }
    }
}
