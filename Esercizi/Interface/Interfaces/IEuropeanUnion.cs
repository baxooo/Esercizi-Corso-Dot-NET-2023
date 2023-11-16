using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    public interface IEuropeanUnion: IEuroZone, IPoliticalOrganization
    {
        public void ConstitutionIntegration();
        public void HumanRightsTribunal();
        public void EMA();
    }
}
