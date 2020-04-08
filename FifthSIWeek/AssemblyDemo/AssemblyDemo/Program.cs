using System;
using System.Reflection;

namespace AssemblyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.dll";

            // Load a specific Assembly
            Assembly assembly = Assembly.LoadFile(path);
            ShowAssemblyInfo(assembly);

            // Get currently executing Assembly
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            ShowAssemblyInfo(currentAssembly);
        }

        static void ShowAssemblyInfo(Assembly assembly)
        {
            Console.WriteLine($"\n{assembly.FullName}\n{assembly.GlobalAssemblyCache}\n{assembly.Location}\n{assembly.ImageRuntimeVersion}");

            foreach (var module in assembly.Modules)
            {
                Console.WriteLine($"\n{module.Name}");
            }
        }
    }
}
