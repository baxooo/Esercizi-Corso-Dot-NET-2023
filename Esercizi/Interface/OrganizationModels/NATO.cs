using Interface.StateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.OrganizationModels
{
    internal class NATO
    {
        List<State> members = new List<State>();
        public NATO() 
        {
        }

        public State EnterNATO(State state)
        {
            try
            {
                NATOState natoState = (NATOState)state;
                members.Add(natoState);
                return natoState;
            }
            catch(InvalidCastException ex) 
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
