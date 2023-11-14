using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.StateModels
{
    /// <summary>
    /// A State that is  part of the European Union and uses the Euro as its currency
    /// </summary>
    internal class EurozoneState : State, IBCE
    {
        public EurozoneState(string name, int pil, string currency, bool usesDeathPunishment,GovernmentType governmentType) : base(name, pil, currency,usesDeathPunishment,governmentType)
        {
            ((IBCE)this).UseEuro();
        }

        void IBCE.UseEuro()
        {
            _currency = "Euro";
        }
    }
}
