using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Interface.SubStateModels
{

    public class ProvinciaEU : AreaGeografica, IEuPublicAdministration
    {
        string _name;
        List<ComuneEU> _comuni = new List<ComuneEU>();
        RegionEU _regioneDiAppartenenza;

        public RegionEU RegioneDiAppartenenza { get { return _regioneDiAppartenenza; } set { _regioneDiAppartenenza = value; } }
        public string Name { get { return _name; } }
        public List<ComuneEU> Comuni {  get { return _comuni; } } 

        public ProvinciaEU(string name, int positionX, int positionY)
            : base(positionX, positionY)
        {
            _name = name;
        }

        public ProvinciaEU(string name, RegionEU regioneDiAppartenenza, int positionX, int positionY)
            : base(positionX, positionY)
        {
            _regioneDiAppartenenza = regioneDiAppartenenza;
            _name = name;
        }

        public void SetRegion(RegionEU region)
        {
            _regioneDiAppartenenza = region;
        }

        public void ChangeRegion(RegionEU region)
        {
            if (_regioneDiAppartenenza == null) return;
            _regioneDiAppartenenza.RemoveProvincia(this, region);
        }

        public void AddComune(ComuneEU comune)
        {
            _comuni.Add(comune);
        }

        /// <summary>
        /// A Comune can be removed from a Provincia, but it must be moved to a new one.
        /// </summary>
        /// <param name="comune"></param>
        /// <param name="newProvincia"></param>
        public void RemoveComune(ComuneEU comune, ProvinciaEU newProvincia)
        {
            _comuni.Remove(comune);
            newProvincia.AddComune(comune);
        }

        public void HNS() => Console.WriteLine($"la provincia {_name} amministra le sue strutture sanitarie");

        public void LawSystem() => Console.WriteLine($"la provincia {_name} amministra le sue strutture burocratiche");

        public void EducationalSystem() => Console.WriteLine($"la provincia {_name} amministra le sue strutture scolastiche");

        public void WelfareServices()
        {
            throw new NotImplementedException();
        }

        public void HNS(EuID id) =>
            Console.WriteLine($"il servizio sanitario della provincia {_name} ha preso in carico il cittadino {id}");

        public void EducationalSystem(EuID id) =>
            Console.WriteLine($"la provincia {_name} ha dato una borsa di studio al cittadino {id}");
    }
}
