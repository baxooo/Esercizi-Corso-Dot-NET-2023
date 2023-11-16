using Interface.Interfaces;
using Interface.StateModels;
using Interface.SubStateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.OrganizationModels
{
    public class EuParliament 
    {
        static Random _rnd = new Random();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state1"></param>
        /// <param name="state2"></param>
        /// <param name="region"></param>
        public static void MoveRegionToOtherCountryRequest(EuropeanUnionState state1,EuropeanUnionState state2,RegionEU region)
        {
            string request = $"request to move {region.Name} from {state1.Name} to {state2.Name} has been ";
            string accepted = "accepted";
            string denied = "denied";
            int n = _rnd.Next(100);
            if(n % 2 == 0)
            {
                Console.WriteLine(request + accepted);
                MoveRegionToOtherCountry(state1 ,state2,region);
            }
            else
                Console.WriteLine(request + denied);
        }

        private static void MoveRegionToOtherCountry(EuropeanUnionState state1, EuropeanUnionState state2, RegionEU region)
        {
            Console.WriteLine($"State {state1.Name} with: {state1.Region.Name}, moves {region.Name} to state {state2.Name}");
            state1.RemoveRegion(region);
            state2.AddRegion(region);
            Console.WriteLine($"State {state1.Name} now has: no region, state {state2.Name} now has: {state2.Region.Name}");
        }

        public static EuropeanUnionState EnterEuropeanUnion(State state)
        {
            if (!IsStateElegible(state))
            {
                return null;
            }

            try
            {
                EuropeanUnionState euState = (EuropeanUnionState)state;
                Console.WriteLine($"state {euState.Name} is now in the European Union");
                return euState;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private static bool IsStateElegible(State state)
        {
            if (state is EuropeanUnionState)
            {
                Console.WriteLine($"this state \"{state.Name}\" is already in the EuropeanUnion");
            }

            if (state.GovernType == GovernmentType.Republica ||
                state.GovernType == GovernmentType.Democrazia ||
                state.GovernType == GovernmentType.MonarchiaCostituzionale)
            {
                Console.WriteLine($"{state.Name} has the requirements to enter the European Union");
                return true;
            }
            
            Console.WriteLine($"{state.Name} doesn't have the minimum requirements to enter the European Union");
            return false;
        }
    }    
}
