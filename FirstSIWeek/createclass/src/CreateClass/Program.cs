using System;

namespace CreateClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Peter", "1964-02-28");
            person.gender = Gender.Male;
            Employee martha = new Employee("Martha", "1976-06-11");
            martha.gender = Gender.Female;

            Console.WriteLine(person.ToString()); 
            Console.WriteLine(martha.ToString()); 
        }
    }
}
