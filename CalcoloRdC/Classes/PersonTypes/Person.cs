using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.PersonTypes
{
    internal abstract class Person
    {
        protected string _name;
        protected string _lastName;
        protected int _age;

        public string Name { get { return _name; } }
        public string LastName { get { return _lastName; } }
        public int Age { get { return _age; } }

        protected Person(string Name, string LastName, int Age)
        {
            _name = Name;
            _lastName = LastName;
            _age = Age;
        }

        public abstract void GetInfo();

        protected abstract bool IsSeniorCitizen();
    }
}
