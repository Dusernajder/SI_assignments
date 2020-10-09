using System;

namespace CreateClass.person
{
    public class Person
    {
        private string Name { get; }
        private DateTime BirthDay { get; }
        private Genders Gender { get; }

        public enum Genders
        {
            Male,
            Female
        }

        public Person(string name, DateTime birthDay, Genders gender)
        {
            Name = name;
            BirthDay = birthDay;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"name: {Name}\n" +
                   $"birth day: {BirthDay}\n" +
                   $"gender: {Gender}";
        }
    }
}