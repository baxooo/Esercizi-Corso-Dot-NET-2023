﻿using Interface.StateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.OrganizationModels
{
    internal class ONU
    {
        public List<State> Members = new List<State>();
        public ONU()
        {
                
        }

        public ONUState EnterONU(State state)
        {
            if (state.GovernType == GovernmentType.MonarchiaAssoluta)
            {
                Console.WriteLine("questo stato non può far parte del ONU");
                return null;
            }

            try
            {
                ONUState onuState = (ONUState)state;
                Members.Add(onuState);
                return onuState;
            }
            catch(InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public void Unicef()
        {

        }
        public void OmsOffice()
        {

        }

        public void FifaOffice()
        {

        }


    }
}
