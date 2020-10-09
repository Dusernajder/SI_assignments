using System;
using CreateClass.person;

namespace CreateClass
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Employee person = new Employee("Géza", DateTime.Now, Person.Genders.Male, 1000, "léhűtő");
            person.Room = new Room(111);
            Console.WriteLine(person);
        }
    }
}