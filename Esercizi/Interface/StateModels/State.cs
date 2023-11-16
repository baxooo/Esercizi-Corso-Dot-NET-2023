using Interface.Interfaces;
using Interface.OrganizationModels;
using Interface.SubStateModels;
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
    public class State : AreaGeografica, IEuCitizenPublicService
    {
        protected int _PIL;
        protected string _name;
        protected string _currency;
        protected RegionEU _region;
        protected GovernmentType _governType;
        protected float _militaryBudgetPercentage;
        protected string _flag;
        protected Random _rnd;
        protected string _army;
        protected string _border;


            

        public State(string name, int pil, string currency, GovernmentType governType, 
            int positionX, int positionY, string army, string border)
            : base(positionX, positionY)
        {
            _name = name;
            _currency = currency;
            _PIL = pil;
            _army = army;
            _border = border;

            Random rnd = new Random();
            _rnd = rnd;

            _militaryBudgetPercentage = (float)rnd.NextDouble() * 4;
        }
        public string Name { get { return _name; } }
        public int PIL { get { return _PIL; } }
        public string Flag { get { return _flag; } }
        public string Currency { get { return _currency; } }
        public RegionEU Region { get { return _region; } }

        public GovernmentType GovernType { get => _governType; }

        public void AddRegion(RegionEU region)
        {
            _region = region;
        }

        public void BorderRedefinition(EuParliament parliament)
        {
            throw new NotImplementedException();
        }

        public void EducationalSystem() => Console.WriteLine($"{_name} ha {_rnd.Next(2000)} scuole");

        public void EducationalSystem(EuID id)
        {
            throw new NotImplementedException();
        }

        public void HNS() => Console.WriteLine($"{_name} ha {_rnd.Next(1000)} istituti di cura");

        public void HNS(EuID id)
        {
            throw new NotImplementedException();
        }

        public void LawSystem() => Console.WriteLine($"{_name} espleta le sue funzioni giuridiche");
        

        public void RemoveRegion(RegionEU region)
        {
            _region = null;
        }

        public void WelfareServices()
        {
            throw new NotImplementedException();
        }
    }
}
