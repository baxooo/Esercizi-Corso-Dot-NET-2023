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
        private int _age;
        private int _gradeMaturita;
        private float _averageUniversityGrade;
        private int _childCount;
        private int _residencePIL;

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

        public Citizen(bool hasServiced, bool isStudent, bool hasDebt, int age, int scoreMaturita, float averageUniversityGrade, int childCount, int residencePIL)
        {
            _hasServiced = hasServiced;
            _isStudent = isStudent;
            _hasDebt = hasDebt;
            _age = age;
            _gradeMaturita = scoreMaturita;
            _averageUniversityGrade = averageUniversityGrade;
            _childCount = childCount;
            _residencePIL = residencePIL;
        }


    }
}
