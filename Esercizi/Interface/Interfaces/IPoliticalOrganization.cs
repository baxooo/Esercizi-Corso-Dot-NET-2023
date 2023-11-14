using Interface.StateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    public interface IPoliticalOrganization
    {
        public List<string> PartiesNames { get; set; }

        public void InternationlRelations(State state);

    }
}
