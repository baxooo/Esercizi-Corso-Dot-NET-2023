using Interface.Interfaces;
using Interface.SubStateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interface.StateModels
{
    /// <summary>
    /// A State that is  part of the European Union but does not necessarily uses the Euro as currency
    /// </summary>
    public class EuropeanUnionState : State, IEuropeanUnion
    {
        public EuropeanUnionState(string name, int pil, string currency, GovernmentType governmentType, 
             int posX,int posY,string army,string border)
            : base(name,pil,currency, governmentType,posX,posY,army,border)
        {
            MonetaUnica();
        }

        public void InternationalRelations()
        {
            Console.WriteLine($"{_name} has good international relationships");
        }

        public void ConstitutionIntegration()
        {
            Console.WriteLine($"Lo stato {_name} ha integrato le leggi europee costituzionali");
        }

        public void HumanRightsTribunal()
        {
            Console.WriteLine($"Lo stato {_name} ha istituito un tribunale per i diritti dell'uomo");
        }


        public void MonetaUnica()
        {
            _currency = "Euro";
        }

        public void EMA()
        {
            Console.WriteLine($"lo stato {_name} aderisce all'Agenzia Europea per i Medicinali");
        }
        public void CreateRegion(string name,int positionX,int positionY)
        {
            RegionEU region = new(name, positionX, positionY);
            _regions.Add(region);
        }
    }
}
