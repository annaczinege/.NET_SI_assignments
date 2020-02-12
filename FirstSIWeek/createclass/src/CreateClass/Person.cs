using System;

namespace CreateClass
{
    public class Person
    {
        public String name {get; set;}
        public String birthDate {get; set;}
        public Gender gender { get; set; }

        public Person(String name, String birthDate) {
            this.name = name;
            this.birthDate = birthDate;
        }

       
        public override String ToString() {
            return "Name of person: " + name + ", Date of Birth: " + birthDate + ", Gender: " + gender;
        }

    }
}
