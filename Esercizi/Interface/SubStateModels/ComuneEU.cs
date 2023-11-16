using Interface.Interfaces;
using Interface.OrganizationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.SubStateModels
{
    public class ComuneEU : City, IEuCitizenPublicService
    {

        CitizenEU sindaco;
        List<CitizenEU> _citizens = new List<CitizenEU>();

        public ComuneEU(string name, int positionX, int positionY) :base(name,positionX,positionY)
        {
            
        }

        public void AddCitizen(CitizenEU citizen)
        {
            _citizens.Add(citizen);
        }

        public void BorderRedefinition(EuParliament parliament)
        {
            throw new NotImplementedException();
        }

        public void EducationalSystem(EuID id) => 
            Console.WriteLine($"la richiesta del cittadino {id} per l'iscrizione agli istituti del comune è stata accettata");
        public void EducationalSystem() => Console.WriteLine($"il comune di {_name} amministra le sue strutture scolastiche");
        public void HNS(EuID id) => 
            Console.WriteLine($"la richiesta del cittadino {id} per la visita medica è stata accettata");
        public void HNS() => Console.WriteLine($"il comune di {_name} amministra le su strutture sanitarie");
        public void LawSystem() => Console.WriteLine($"il comune di {_name} amministra le sue strutture burocratiche");
        /// <summary>
        /// a Citizen can be removed from a Comune, but it must be moved to a new one.
        /// </summary>
        /// <param name="citizen"></param>
        /// <param name="newComune"></param>
        public void RemoveCitizen(CitizenEU citizen, ComuneEU newComune)
        {
            _citizens.Remove(citizen);
            newComune.AddCitizen(citizen);
        }

        public void WelfareServices()
        {
            throw new NotImplementedException();
        }

        internal EuID GetIdCard(CitizenEU citizenEU)
        {
            Random rnd = new Random();
            EuID id = new EuID(rnd.Next(10000),citizenEU.Name,citizenEU.LastName);

            return id;
        }
    }
}
