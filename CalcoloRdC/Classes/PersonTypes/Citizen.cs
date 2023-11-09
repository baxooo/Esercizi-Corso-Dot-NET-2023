using System;

namespace Classes.PersonTypes
{
    internal class Citizen : Person
    {
        private bool _hasServiced;
        private bool _hasDebt;
        private bool _isSenior;
        private bool _hasIncome;
        private int _childCount;
        private int _residencePIL;

        public bool IsSenior { get { return _isSenior; } }
        public bool HasIncome
        {
            get { return _hasIncome; }
        }
        public bool HasServiced
        {
            get { return _hasServiced; }
        }
        public bool HasDebt
        {
            get { return _hasDebt; }
        }
        public int ChildCount
        {
            get { return _childCount; }
        }
        public int ResidencePIL { get { return _residencePIL; } }

        public Citizen(string Name, string LastName, int Age,
            bool hasDebt, bool hasIncome,
            int childCount, int residencePIL)
            : base(Name, LastName, Age)
        {
            _hasDebt = hasDebt;
            _hasIncome = hasIncome;

            if (Age > 0)
                _age = Age;

            if (childCount > 0)
                _childCount = childCount;

            if (residencePIL > 0)
                _residencePIL = residencePIL;

            _isSenior = IsSeniorCitizen();
        }

        protected override bool IsSeniorCitizen()
        {
            if (_age >= 60)
                return true;

            return false;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"{_name} {_lastName}, {Age}");
        }
    }
}
