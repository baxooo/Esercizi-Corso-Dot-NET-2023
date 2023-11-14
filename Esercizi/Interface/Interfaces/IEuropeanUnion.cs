using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    public interface IEuropeanUnion: IBCE, IPoliticalOrganization
    {
        public void ConstitutionIntegration();
        public void HumanRightsTribunal();
        void NoDeathPunishment();
    }
}
