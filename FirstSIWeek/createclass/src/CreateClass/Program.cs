using System;

namespace CreateClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Peter", "1964-02-28");
            person.gender = Gender.Male;
            Console.WriteLine(person.ToString()); 
        }
    }
}
