using System;
using System.Reflection;

namespace AssemblyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "/usr/local/share/dotnet/packs/Microsoft.NETCore.App.Ref/5.0.0/ref/net5.0/System.dll";

            Assembly assembly = Assembly.LoadFile(path);
            ShowAssembly(assembly);

            Console.WriteLine();

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            ShowAssembly(currentAssembly);

            Console.Read();
        }

        static void ShowAssembly(Assembly assembly)
        {
            Console.WriteLine($"Full name: {assembly.FullName}");
            Console.WriteLine($"Global assembly: {assembly.GlobalAssemblyCache}");
            Console.WriteLine($"Location: {assembly.Location}");
            Console.WriteLine($"Image runtime version: {assembly.ImageRuntimeVersion}");

            Console.WriteLine("Modules:");
            foreach (Module module in assembly.GetModules())
            {
                Console.WriteLine(module.Name);
            }
        }
    }
}