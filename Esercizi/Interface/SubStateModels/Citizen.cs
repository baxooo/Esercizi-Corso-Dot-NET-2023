using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.NewFolder
{
    public class Citizen
    {
        private string _name;
        private string _lastName;
        private string _birthDay;
        private Comune _comuneDiResidenza;

        public string Name { get { return _name; } }
        public string LastName { get { return _lastName; } }
        public string BirthDay { get { return _birthDay; } }  
        public Comune ComuneDiResidenza { get { return _comuneDiResidenza; } }


        public Citizen(string name, string lastName, string birthDay)
        {
            _name = name;
            _lastName = lastName;
            _birthDay = birthDay;
        }

        public void SetComuneDiResidenza(Comune comune)
        {
            _comuneDiResidenza = comune;
        }

        public void ChangeComuneDiResidenza(Comune newComune)
        {
            _comuneDiResidenza.RemoveCitizen(this, newComune);
        }

    }
}
