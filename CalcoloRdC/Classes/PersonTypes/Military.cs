using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.PersonTypes
{
    internal class Military : Citizen
    {
        protected int _yearsOfService;
        protected int _numeroMatricola;
        public int YearsOfService { get { return _yearsOfService; } }
        public Military(string Name, string LastName, int Age, bool hasDebt,
            bool hasIncome, int childCount, int residencePIL, int yearsOfService, int numeroMatricola)
            : base(Name, LastName, Age, hasDebt, hasIncome, childCount, residencePIL)
        {
            _yearsOfService = yearsOfService;
            _numeroMatricola = numeroMatricola;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"{_name} {_lastName},età {Age}, anni di servizio {_yearsOfService}");
        }
    }
}
