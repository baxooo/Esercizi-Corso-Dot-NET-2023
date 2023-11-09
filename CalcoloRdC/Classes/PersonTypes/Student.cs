using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.PersonTypes
{
    internal class Student : Citizen
    {
        protected int _gradeMaturita;

        public int GradeMaturita { get { return _gradeMaturita; } }
        public Student(string Name, string LastName, int Age,
            bool hasDebt, bool hasIncome, int gradeMaturita,
            float averageUniversityGrade, int childCount,
            int residencePIL) : base(Name, LastName, Age, hasDebt,
                hasIncome, childCount, residencePIL)
        {

            if (gradeMaturita > 0 && gradeMaturita < 100)
                _gradeMaturita = gradeMaturita;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"{_name} {_lastName},età {Age}, voto maturità {_gradeMaturita}");
        }
    }
}
