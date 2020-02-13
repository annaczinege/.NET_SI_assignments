using System;
using System.Collections.Generic;
using System.Text;

namespace CreateClass
{
    class Employee : Person, IClonable
    {
        public int Salary { get; set; }
        public string Profession { get; set; }
        public Room Room { get; set; }

        public Employee(string name, DateTime birthDate, Room Room) : base(name, birthDate)
        {
            this.Room = Room;
        }

        public override string ToString()
        {
            return $"Name of Employee: {name}, Salary: {Salary}, Profession: {Profession}, Room number: {Room.Number}";
        }

        public object Clone()
        {
            Employee newEmployee = (Employee)this.MemberwiseClone();
            newEmployee.Room = new Room(Room.Number);
            return newEmployee;
        }

    }
}
