using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.PersonTypes
{
    internal class UniversityStudent : Student
    {
        protected float _averageUniGrade;
        public float AverageUniversityGrade { get { return _averageUniGrade; } }
        public UniversityStudent(string Name, string LastName, int Age,
            bool hasDebt, bool hasIncome, int gradeMaturita,
             int childCount, int residencePIL, float averageUniversityGrade)
            : base(Name, LastName, Age, hasDebt, hasIncome, gradeMaturita,
                  averageUniversityGrade, childCount, residencePIL)
        {
            _averageUniGrade = averageUniversityGrade;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"{_name} {_lastName},età {Age}, voto maturità {_gradeMaturita}, media università {_averageUniGrade}");
        }
    }
}
