using System;
using CreateClass.person;

namespace CreateClass
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Person person = new Person("Jack", new DateTime(1980, 01, 01), Person.Genders.Male);
            Console.WriteLine(person);
        }
    }
}