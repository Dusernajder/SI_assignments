using System;
using System.Reflection;
using System.Reflection.Emit;

namespace DynamicAssemblyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyName assemblyName = new AssemblyName
            {
                Name = "DemoAssembly",
                Version = new Version("1.0.0.0")
            };

            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicAssemblyDemo.dll");
            var typeBuilder = moduleBuilder.DefineType("Animal", TypeAttributes.Public);

            Type animal = typeBuilder.CreateType();
            Console.WriteLine(animal?.FullName);

            foreach (MemberInfo info in animal?.GetMembers())
            {
                Console.WriteLine($"Member ({info.MemberType}): {info.Name}");
            }

            Console.ReadKey();
        }
    }
}