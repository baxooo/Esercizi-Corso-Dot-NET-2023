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
    internal class EurozoneState : EuropeanUnionState, IEuroZone
    {
        public EurozoneState(string name, int pil, string currency, GovernmentType governmentType,
            int posX,int posY,string army, string border) 
            : base(name, pil, currency, governmentType, posX, posY,army,border)
        {
            MonetaUnica();
        }
    }
}
