using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.StateModels
{
    /// <summary>
    /// A State that is  part of the European Union but does not necessarily uses the Euro as currency
    /// </summary>
    internal class EuropeanUnionState : State, IEuropeanUnion
    {
        public EuropeanUnionState(string name,int pil, string currency, bool usesDeathPunishment = false) 
            : base(name,pil,currency, usesDeathPunishment)
        {
            ((IEuropeanUnion)this).NoDeathPunishment();
        }

        void IEuropeanUnion.ConstitutionIntegration()
        {
            Console.WriteLine($"Lo stato {_name} ha integrato le leggi europee costituzionali");
        }

        void IEuropeanUnion.HumanRightsTribunal()
        {
            Console.WriteLine($"Lo stato {_name} ha istituito un tribunale per i diritti dell'uomo");
        }

        void IEuropeanUnion.NoDeathPunishment()
        {
            _usesDeathPunishment = false;
        }

        void IBCE.UseEuro()
        {
            _currency = "Euro";
        }
    }
}
