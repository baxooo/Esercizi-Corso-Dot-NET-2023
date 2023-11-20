using Interface.OrganizationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    internal interface IEntitaAmministrativaEU : IEntitaAmministrativa
    {
        public void BorderRedefinition(EuParliament parliament);
    }
}
