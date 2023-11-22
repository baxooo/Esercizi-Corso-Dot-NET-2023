using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Models
{
    internal class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Customer(int age,string name)
        {
            Age = age;
            Name = name;
        }
    }
}
