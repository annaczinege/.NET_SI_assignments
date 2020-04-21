using System;
using System.Collections.Generic;

namespace BinarySearchTreeDojo
{
    public class Program
    {
        public List<int> GenerateNumbers(int numOfItems)
        {
            var result = new List<int>();

            for (int i = 0; i < numOfItems; ++i)
            {
                result.Add(i * 2 + 5);
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Run the tests!");
            Console.ReadKey();
        }
    }
}
