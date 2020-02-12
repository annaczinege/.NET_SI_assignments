using System;
using System.Collections.Generic;
using System.Text;

namespace CreateClass
{
    public class Employee : Person
    {
        public int Salary { get; set; }
        public string Profession { get; set; }
        private Room room;

        public Employee(string name, string birthDate) : base(name, birthDate)
        {
            room = null;
        }

        public override string ToString()
        {
            return $"Name of Employee: {name}, Salary: {Salary}, Profession: {Profession}";
        }
    }
}
