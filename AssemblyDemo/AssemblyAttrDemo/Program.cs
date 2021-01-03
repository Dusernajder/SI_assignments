using System;
using System.Reflection;

namespace AssemblyAttrDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Type type = typeof(AssemblyDescriptionAttribute);
            object[] customAttributes = currentAssembly.GetCustomAttributes(type, false);

            if (customAttributes.Length > 0)
            {
                var assemblyDescriptionAttribute = (AssemblyDescriptionAttribute) customAttributes[0];
                Console.WriteLine($"Description: {assemblyDescriptionAttribute.Description}");
            }

            Console.ReadKey();
        }
    }
}