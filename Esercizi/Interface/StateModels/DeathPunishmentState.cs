using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.StateModels
{
    internal class DeathPunishmentState : State, IDeathPunishmentState
    {
        protected bool _deathPunishment;
        public DeathPunishmentState(string name, int pil, string currency, 
            GovernmentType governType, int positionX, int positionY,string army,string border) 
            : base(name, pil, currency, governType, positionX, positionY,army,border)
        {
            _deathPunishment = true;
        }

        public bool UsesDeathPunishment => _deathPunishment;
    }
}
