using System;
using System.Reflection;

namespace DynamicCodeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "/usr/local/share/dotnet/packs/Microsoft.NETCore.App.Ref/5.0.0/ref/net5.0/System.Web.dll";
            Assembly assembly = Assembly.LoadFile(path);
            Type type = assembly.GetType("System.Web.HttpUtility");

            MethodInfo encode = type?.GetMethod("HtmlEncode", new[] {typeof(string)});
            MethodInfo decode = type?.GetMethod("HtmlDecode", new[] {typeof(string)});

            string originalString = "This is Sally & Jack's Anniversary <sic>";
            Console.WriteLine(originalString);

            string encodedStr = (string) encode?.Invoke(null, new object[] {originalString});
            Console.WriteLine($"Encoded: {encodedStr}");
            string decodedStr = (string) decode?.Invoke(null, new object[] {encodedStr});
            Console.WriteLine($"Decoded: {decodedStr}");

            Console.ReadKey();
        }
    }
}