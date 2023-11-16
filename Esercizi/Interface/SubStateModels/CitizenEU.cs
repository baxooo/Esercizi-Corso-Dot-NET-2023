using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.SubStateModels
{
    public class CitizenEU
    {
        private string _name;
        private string _lastName;
        private string _birthDay;
        private ComuneEU _comuneDiResidenza;

        public EuID ID { get; private set; }

        public string Name { get { return _name; } }
        public string LastName { get { return _lastName; } }
        public string BirthDay { get { return _birthDay; } }  
        public ComuneEU ComuneDiResidenza { get { return _comuneDiResidenza; } }


        public CitizenEU(string name, string lastName, string birthDay, ComuneEU comuneDiResidenza)
        {
            _name = name;
            _lastName = lastName;
            _birthDay = birthDay;
            _comuneDiResidenza = comuneDiResidenza;
            ID = _comuneDiResidenza.GetIdCard(this);
        }

        public void ChangeComuneDiResidenza(ComuneEU newComune)
        {
            _comuneDiResidenza.RemoveCitizen(this, newComune);
        }

    }
}
