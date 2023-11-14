using Interface.StateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Interface.OrganizationModels
{
    internal class EuropeanUnion
    {
        public List<EuropeanUnionState> Members = new List<EuropeanUnionState>();

        public EuropeanUnion()
        {

        }

        public State EnterEuropeanUnion(State state)
        {
            if (!IsStateElegible(state)) 
                return state;

            try
            {
                EuropeanUnionState euState = (EuropeanUnionState)state;
                Members.Add(euState);
                return euState;
            }
            catch(InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private bool IsStateElegible(State state)
        {
            if (state is EuropeanUnionState)
                return false;

            if (state.UsesDeathPunishment)
            {
                Console.WriteLine("Request Denied.");
                return false;
            }

            if(state.GovernType == GovernmentType.Republica ||
                state.GovernType == GovernmentType.Democrazia|| 
                state.GovernType == GovernmentType.MonarchiaCostituzionale)
            {
                Console.WriteLine("Request Accepted.");
                return true;
            }
            else return false;

           
        }
    }
}
