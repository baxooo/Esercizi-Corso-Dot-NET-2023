using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Interface.SubStateModels
{

    public class RegionEU : AreaGeografica, IEuPublicAdministration
    {
        private string _name;
        ProvinciaEU _provincia;

        public RegionEU(string name,int positionX, int positionY) : base(positionX, positionY)
        {

        }

        public string Name { get { return _name; } }

        public void AddProvincia(ProvinciaEU provincia)
        {
            _provincia = provincia;
        }

        public void EducationalSystem() => 
            Console.WriteLine($"la regione {_name} amministra le sue strutture scolastiche");
        public void EducationalSystem(EuID id) => 
            Console.WriteLine($"la regione {_name} fornisce i test di maturita per il cittadino{id}");
        public void HNS() => Console.WriteLine($"la regione {_name} amministra le sue strutture sanitarie");
        public void HNS(EuID id) => 
            Console.WriteLine($"la regione {_name} ha pagato l'ospedalizzazione del cittadino {id}");
        public void LawSystem() => Console.WriteLine($"la regione {_name} amministra le sue strutture burocratiche");

        /// <summary>
        /// A Provincia can be removed form the Region, but it must be moved to a new region.
        /// </summary>
        /// <param name="provincia"></param>
        /// <param name="newRegion"></param>
        public void RemoveProvincia(ProvinciaEU provincia,RegionEU newRegion) 
        {
            _provincia = null;
            newRegion.AddProvincia(provincia);
        }

        public void WelfareServices()
        {
            throw new NotImplementedException();
        }
    }
}
