using System;

namespace CreateClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Peter", new DateTime(1964, 2, 28));
            person.gender = Gender.Male;
            Employee martha = new Employee("Martha", new DateTime(1976, 11, 12), new Room(13));
            martha.gender = Gender.Female;
            martha.Salary = 500000;
            martha.Profession = "Chef";

            //IClonable interface
            Employee martha2 = (Employee)martha.Clone();
            martha2.Room = new Room(102);

            Console.WriteLine(person.ToString()); 
            Console.WriteLine(martha.ToString()); 
            Console.WriteLine(martha2.ToString());
            //Console.ReadKey();
            //dont close terminal until key is pressed
        }
    }
}
