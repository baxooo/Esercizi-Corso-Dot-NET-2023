using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.StateModels
{
    internal class State : IEntitaAmministrativa, IDeathPunishmentState
    {
        protected int _PIL;
        protected string _name;
        protected string _currency;
        protected bool _usesDeathPunishment;

        public State(string name, int pil, string currency, bool usesDeathPunishment)
        {
            _name = name;
            _currency = currency;
            _PIL = pil;
            _usesDeathPunishment = usesDeathPunishment;
        }
        public string Name { get { return _name; } }
        public int PIL { get { return _PIL; } }
        public string Currency { get { return _currency; } }

        bool IDeathPunishmentState.UsesDeathPunishment { get => _usesDeathPunishment; }

        void IEntitaAmministrativa.EseguiServizio()
        {
            Console.WriteLine($"Lo stato {_name} ha aperto nuove scuole");
            Console.WriteLine($"Lo stato {_name} ha eseguito la manutenzione della strada");
        }
    }
}
