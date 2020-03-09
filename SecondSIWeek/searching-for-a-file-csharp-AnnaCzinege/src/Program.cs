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

            void DirSearch(string sDir)
            {
                try
                {
                    foreach (string d in Directory.GetDirectories(sDir))
                    {
                        foreach (string f in Directory.GetFiles(d, txtFile.Text))
                        {
                            lstFilesFound.Items.Add(f);
                        }
                        DirSearch(d);
                    }
                }
                catch (System.Exception excpt)
                {
                    Console.WriteLine(excpt.Message);
                }
            }
        }
    }
}
