using System;
using System.Collections.Generic;
using System.Text;

namespace SortString
{
    class StringSorter
    {

        public void SortString(string String)
        {
            string[] Words = String.Split(' ');
            Array.Sort(Words);
            string NewString = string.Join(" ", Words);
            Console.WriteLine(NewString);
        }
    }
}
