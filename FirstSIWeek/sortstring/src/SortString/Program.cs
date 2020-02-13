using System;

namespace SortString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Microsoft .NET Framework 2.0 Application Development Foundation";

            StringSorter stringSorter = new StringSorter();
            stringSorter.SortString(str);
        }
    }
}
