using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Citizen
    {
        private bool _hasServiced;
        private bool _isStudent;
        private bool _hasDebt;
        private bool _hasIncome;
        private int _age;
        private int _gradeMaturita;
        private float _averageUniversityGrade;
        private int _childCount;
        private int _residencePIL;

        public bool HasIncome
        {
            get { return _hasIncome; }
        }
        public bool HasServiced
        {
            get { return _hasServiced; }
        }
        public bool IsStudent
        {
            get { return _isStudent; }
        }
        public bool HasDebt
        {
            get { return _hasDebt; }
        }
        public int Age
        {
            get { return _age; }
        }
        public int GradeMaturita
        {
            get { return _gradeMaturita; }
        }
        public float AverageUniversityGrade
        {
            get { return _averageUniversityGrade; }
        }
        public int ChildCount
        {
            get { return _childCount; }
        }
        public int ResidencePIL { get { return _residencePIL; } }

        public Citizen(bool hasServiced, bool isStudent, bool hasDebt,bool hasIncome, int age, int gradeMaturita, float averageUniversityGrade, int childCount, int residencePIL)
        {
            _hasServiced = hasServiced;
            _isStudent = isStudent;
            _hasDebt = hasDebt;
            _hasIncome = hasIncome;

            if (age > 0)
                _age = age;

            if (gradeMaturita > 0 && gradeMaturita < 100)
                _gradeMaturita = gradeMaturita;

            if (childCount > 0)
                _childCount = childCount;

            if (averageUniversityGrade > 0 && averageUniversityGrade > 30)
                _averageUniversityGrade = averageUniversityGrade;

            if(residencePIL > 0)
            _residencePIL = residencePIL;
        }


    }
}
