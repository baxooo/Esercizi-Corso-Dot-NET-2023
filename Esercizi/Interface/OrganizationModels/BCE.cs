using Interface.StateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.OrganizationModels
{
    internal class BCE
    {
        public BCE()
        {
            
        }

        public State EnterEuroZone(State state)
        {
            if (state.PIL <= 300)
                return null;

            try
            {
                EurozoneState eurozoneState = (EurozoneState)state;
                return eurozoneState;
            }
            catch(InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
