using System;

namespace CreateClass.person
{
    public class Employee : Person
    {
        private double _salary;
        private string _profession;
        private Room _room;

        public double Salary
        {
            get => _salary;
            set => _salary = value;
        }

        public string Profession
        {
            get => _profession;
            set => _profession = value;
        }

        public Room Room
        {
            get => _room;
            set => _room = value;
        }

        public Employee(string name, DateTime birthDay, Genders gender, double salary, string profession) : base(name,
            birthDay, gender)
        {
            _salary = salary;
            _profession = profession;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"salary: {Salary}\n" +
                   $"profession: {Profession}\n" +
                   "room: " + (_room != null ? $"{Room}" : "No room provided") + "\n";
        }
    }
}