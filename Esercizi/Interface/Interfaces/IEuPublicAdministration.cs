using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    internal interface IEuPublicAdministration
    {
        public void WelfareServices();
        public void HNS(EuID id);
        public void EducationalSystem(EuID id);
    }
}
