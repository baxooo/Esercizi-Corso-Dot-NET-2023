using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.NewFolder
{
    public class Comune
    {
        List<Citizen> _citizens = new List<Citizen>();
        City _city;

        public Comune(City city)
        {
            _city = city;
        }

        public void AddCitizen(Citizen citizen)
        {
            _citizens.Add(citizen);
        }

        /// <summary>
        /// a Citizen can be removed from a Comune, but it must be moved to a new one.
        /// </summary>
        /// <param name="citizen"></param>
        /// <param name="newComune"></param>
        public void RemoveCitizen(Citizen citizen, Comune newComune)
        {
            _citizens.Remove(citizen);
            newComune.AddCitizen(citizen);
        }
    }
}
