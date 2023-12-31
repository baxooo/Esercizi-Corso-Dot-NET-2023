﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface.Interfaces;

namespace Interface.StateModels
{
    internal class NATOState : State, INATO
    {
        
        public NATOState(string name, int pil,string currency, GovernmentType governmentType,
            int posX, int posY,string army,string border)
            :base(name, pil, currency, governmentType, posX, posY,army,border)
        {
            MilitaryBudgetAt2Percent();
        }
        public void MilitaryBudgetAt2Percent()
        {
            if (_militaryBudgetPercentage <= 1.99f)
                _militaryBudgetPercentage = 2;
        }
    }
}
