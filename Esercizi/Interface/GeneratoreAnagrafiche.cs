using Interface.StateModels;
using Interface.SubStateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public  class GeneratoreAnagrafiche
    {
        private string[] _nomi = new string[] { "Marco","Claudio","Giuseppe","Antonio","Alessandro","Andrea","Alberto",
            "Alberto","Giulio","Franco","Francesco","Francesca","Giulia","Flavio","Laurena","Sara","Alessia","Barbara"
        };
        private string[] _cognomi = new string[] { "Pepe","Roberti","Stanislao","Di Pea","Proietti","Ferrante","Rossi",
            "Grassi","Ferri"
        };
        private Random _rnd = new Random();
        private static DateTime _start = new DateTime(1930,1,1);
        private int range = (DateTime.Today - _start).Days;

        private CitizenEU GeneraPersona(ComuneEU comune)
        {
            string name = _nomi[_rnd.Next(_nomi.Length)];
            string lastName = _cognomi[_rnd.Next(_cognomi.Length)];
            string dateOfBirth = _start.AddDays(_rnd.Next(range)).ToString("dd/MM/yyyy");
            var citizen = new CitizenEU(name, lastName, dateOfBirth, comune);
            return citizen;
        }

        public void SmistaPopolazione(State state, int citizens)
        {
            int regions = state.Region.Count;
            int splitByRegion = citizens / regions;
            
            foreach(RegionEU region in state.Region)
            {
                foreach(ProvinciaEU prov in region.Province)
                {
                    int splitByProvince = splitByRegion / region.Province.Count;
                    foreach(ComuneEU com in prov.Comuni)
                    {
                        int splitByComune = splitByProvince / prov.Comuni.Count;
                        com.SetMaxCitizen(splitByComune);
                        Console.WriteLine(com.Name +" " +splitByComune);
                        for (int i = 0; i < splitByComune; i++)
                        {
                            com.AddCitizen(GeneraPersona(com));
                        }

                        Console.WriteLine(com.Name + com.Citizen.Length);
                    }
                }
            }
        }
    }
}
