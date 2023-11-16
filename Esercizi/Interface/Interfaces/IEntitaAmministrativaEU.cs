using Interface.OrganizationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    public interface IEntitaAmministrativaEU : IEntitaAmministrativa
    {
        public void BorderRedefinition(EuParliament parliament);
    }
}
