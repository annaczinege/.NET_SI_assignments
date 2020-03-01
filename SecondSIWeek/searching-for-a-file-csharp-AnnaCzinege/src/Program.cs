using System;
using System.IO;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] directories = Directory.GetDirectories("C:\\");
            string[] files = Directory.GetFiles("C:\\", "*.dll");
        }
    }
}
