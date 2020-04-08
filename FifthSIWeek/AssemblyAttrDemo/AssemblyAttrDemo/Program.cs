using System;
using System.Reflection;

namespace AssemblyAttrDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Type attributeType = typeof(AssemblyDescriptionAttribute);

            object[] attributes = currentAssembly.GetCustomAttributes(attributeType, false);

            if (attributes.Length > 0)
            {
                var description = (AssemblyDescriptionAttribute)attributes[0];
                Console.WriteLine("Description is: {0}", description.Description);
            }
        }
    }
}
