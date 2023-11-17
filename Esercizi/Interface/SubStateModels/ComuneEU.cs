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
        static int _maxCitizen;
        CitizenEU[] _citizens = new CitizenEU[_maxCitizen];
        public CitizenEU[] Citizen { get { return _citizens; } }

        public ComuneEU(string name, int positionX, int positionY) : base(name, positionX, positionY)
        {
            
        }

        public void AddCitizen(CitizenEU citizen)
        {
            if(_citizens.Length == _maxCitizen)
            {
                Console.WriteLine("non è possibile aggiungere un nuovo cittadino");
                return;
            }

           _citizens.Append(citizen);
        }

        public void RemoveCitizen(CitizenEU citizen, ComuneEU newComune)
        {
            _citizens = _citizens.Where(c => c != citizen).ToArray();
            newComune.AddCitizen(citizen);
        }
        public void SetMaxCitizen(int size)
        {
            _maxCitizen = size;
            Array.Resize(ref _citizens, size);
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
