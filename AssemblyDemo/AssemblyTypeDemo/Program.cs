using System;
using System.Reflection;

namespace AssemblyTypeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "/usr/local/share/dotnet/packs/Microsoft.NETCore.App.Ref/5.0.0/ref/net5.0/System.ServiceProcess.dll";

            BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;
            Assembly assembly = Assembly.LoadFrom(path);

            Console.WriteLine($"Full name: {assembly.FullName}");
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                Console.WriteLine($"Type: {type.Name}");
                MemberInfo[] members = type.GetMembers(flags);

                foreach (MemberInfo member in members)
                {
                    Console.WriteLine($"Types: {member.MemberType}\tName: {member.Name}");
                }
            }

            Console.ReadKey();
        }
    }
}