using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.NewFolder
{
    public class Provincia : IEntitaAmministrativa
    {
        string _name;
        List<Comune> _comuni = new List<Comune>();
        Region _regioneDiAppartenenza;

        public Region RegioneDiAppartenenza { get { return _regioneDiAppartenenza; } set { _regioneDiAppartenenza = value; } }

        
        public Provincia(string name)
        {
            _name = name;
        }

        public Provincia(string name, Region regioneDiAppartenenza)
        {
            _regioneDiAppartenenza = regioneDiAppartenenza;
            _name = name;
        }

        public void SetRegion(Region region)
        {
            _regioneDiAppartenenza = region;
        }

        public void ChangeRegion(Region region)
        {
            if (_regioneDiAppartenenza == null) return;
            _regioneDiAppartenenza.RemoveProvincia(this, region);
        }

        public void AddComune(Comune comune)
        {
            _comuni.Add(comune);
        }

        /// <summary>
        /// A Comune can be removed from a Provincia, but it must be moved to a new one.
        /// </summary>
        /// <param name="comune"></param>
        /// <param name="newProvincia"></param>
        public void RemoveComune(Comune comune,Provincia newProvincia)
        {
            _comuni.Remove(comune);
            newProvincia.AddComune(comune);
        }

        void IEntitaAmministrativa.EseguiServizio()
        {
            Console.WriteLine("ristruttura le scuole");
        }
    }
}
