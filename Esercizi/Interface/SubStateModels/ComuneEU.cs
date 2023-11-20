using Interface.Interfaces;
using Interface.OrganizationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.SubStateModels
{
    internal class ComuneEU : City, IEuCitizenPublicService
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
            if(_citizens[_maxCitizen - 1] != null)
            {
                Console.WriteLine("non è possibile aggiungere un nuovo cittadino");
                return;
            }
            int index;
            var last = _citizens.LastOrDefault(c => c != null);
            
            if (last == null)
                index = 0;
            else
            {
                index = Array.IndexOf(_citizens, last);
                _citizens[index + 1] = citizen;
                return;
            }

            _citizens[index] = citizen;
        }
        /// <summary>
        /// a Citizen can be removed from a Comune, but it must be moved to a new one.
        /// </summary>
        /// <param name="citizen"></param>
        /// <param name="newComune"></param>
        public void RemoveCitizen(CitizenEU citizen, ComuneEU newComune)
        {
            _citizens = _citizens.Where(c => c != citizen).ToArray();
            newComune.AddCitizen(citizen);
        }
        public void SetMaxCitizens(int size)
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
