using System;
using System.Collections.Generic;
using System.Text;

namespace CreateClass
{
    public class Room
    {
        public int Number { get => Number; set => Number = value; }

        public Room(int number)
        {
            Number = number;
        }
    }
}
