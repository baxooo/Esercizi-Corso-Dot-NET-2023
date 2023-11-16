using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public struct EuID
    {
        private int _id;
        private string _name;
        private string _lastName;

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string LastName { get { return _lastName; } }

        public EuID(int Id, string name,string lastName)
        {
            _id = Id;
            _name = name;
            _lastName = lastName;
        }
    }
}
