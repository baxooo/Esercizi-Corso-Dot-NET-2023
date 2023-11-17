using Interface.Interfaces;
using Interface.SubStateModels.RegionEU;
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
        private static int _numeroDiProvince;
        ProvinciaEU[] _province = new ProvinciaEU[_numeroDiProvince];

        public string Name { get { return _name; } }
        public ProvinciaEU[] Province { get { return _province; } }

        public RegionEU(string name, int positionX, int positionY, int numeroDiProvince) : base(positionX, positionY)
        {
            _name = name;
        }

        

        public void AddProvincia(ProvinciaEU provincia)
        {
            if(_numeroDiProvince == _province.Length)
            {
                Array.Resize(ref _province, _numeroDiProvince++);
            }

            _province.Append(provincia);
        }
        public void RemoveProvincia(ProvinciaEU provincia, RegionEU newRegion)
        {
            _province = _province.Where(p => p != provincia).ToArray();
            newRegion.AddProvincia(provincia);
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


        public void WelfareServices()
        {
            throw new NotImplementedException();
        }

    }
}
