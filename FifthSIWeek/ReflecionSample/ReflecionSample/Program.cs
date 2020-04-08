using System;
using System.Reflection;

namespace ReflecionSample
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nReflection.MethodInfo");

            // Create Calculator object
            Calculator calculator = new Calculator();

            // Get the Type information.
            Type type = calculator.GetType();

            // Get Method Information.
            MethodInfo myMethodInfo = type.GetMethod("AddNumb");

            bool isAbstarct = type.IsAbstract;

            object[] mParam = new object[] { 5, 10 };

            // Get and display the Invoke method.
            Console.Write("\nFirst method -  Abstract: " + isAbstarct + ", " + type.FullName + " returns " +
                                 myMethodInfo.Invoke(calculator, mParam) + "\n");

            // Get type of CalculatorReflection
            Type type1 = typeof(CalculatorReflection);

            //Create an instance of the type
            object obj = Activator.CreateInstance(type1);
            object[] mParam1 = new object[] { 5, 10 };
            //invoke AddMethod, passing in two parameters
            int result = (int)type1.InvokeMember("AddNumb", BindingFlags.InvokeMethod,
                                               null, obj, mParam1);
            Console.Write("Result: {0} \n", result);
        }
    }
}
