using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.NewFolder
{

    public class Region : IEntitaAmministrativa
    {
        private string _name;
        List<Provincia> _province = new List<Provincia>();

        public Region(string name)
        {
            _name = name;
        }

        public void AddProvincia(Provincia provincia)
        {
            _province.Add(provincia);
        }

        /// <summary>
        /// A Provincia can be removed form the Region, but it must be moved to a new region.
        /// </summary>
        /// <param name="provincia"></param>
        /// <param name="newRegion"></param>
        public void RemoveProvincia(Provincia provincia,Region newRegion) 
        { 
            _province.Remove(provincia);
            newRegion.AddProvincia(provincia);
        }

        void IEntitaAmministrativa.EseguiServizio()
        {
            Console.WriteLine("organizza la sanità");
        }
    }
}
