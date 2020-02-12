using System;
using System.Collections.Generic;
using System.Text;

namespace CreateClass
{
    public class Employee : Person
    {
        public int Salary { get; set; }
        public string Profession { get; set; }

        public Employee(string name, string birthDate) : base(name, birthDate)
        {
        }
    }
}
