using Interface.Interfaces;
using Interface.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.StateModels
{
    public enum GovernmentType
    {
        Democrazia = 0,
        Monarchia = 1,
        MonarchiaCostituzionale = 2,
        MonarchiaAssoluta= 3,
        Republica = 4,
        Oligarchia = 5,
        Teocrazia = 6,
    }
    public class State : AreaGeografica,IEntitaAmministrativa, IDeathPunishmentState
    {
        protected int _PIL;
        protected string _name;
        protected string _currency;
        protected bool _usesDeathPunishment;
        protected List<Region> _regions = new List<Region>();
        protected GovernmentType _governType;
        protected float _militaryBudgetPercentage;
            

        public State(string name, int pil, string currency, bool usesDeathPunishment, GovernmentType governType, int positionX,int positionY)
            : base(positionX,positionY)
        {
            _name = name;
            _currency = currency;
            _PIL = pil;
            _usesDeathPunishment = usesDeathPunishment;

            Random rnd = new Random();

            _militaryBudgetPercentage = (float)rnd.NextDouble() * 4;
        }
        public string Name { get { return _name; } }
        public int PIL { get { return _PIL; } }
        public string Currency { get { return _currency; } }
        public bool UsesDeathPunishment { get { return _usesDeathPunishment; } }

        bool IDeathPunishmentState.UsesDeathPunishment { get => _usesDeathPunishment; }

        public GovernmentType GovernType { get => _governType; }

        void IEntitaAmministrativa.EseguiServizio()
        {
            Console.WriteLine($"Lo stato {_name} ha aperto nuove scuole");
            Console.WriteLine($"Lo stato {_name} ha eseguito la manutenzione della strada");
        }

        public void AddRegion(Region region)
        {
            _regions.Add( region );
        }

        public void RemoveRegion(Region region)
        {
            _regions.Remove( region );
        }
    }
}
