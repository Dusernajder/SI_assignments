using System;

namespace CreateClass.person
{
    public class Person
    {
        private string _name;
        private DateTime _birthDay;
        private Genders _gender;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public DateTime BirthDay
        {
            get => _birthDay;
            set
            {
                if (value.Year > 1900)
                {
                    _birthDay = value;
                }
            }
        }

        public Genders Gender
        {
            get => _gender;
            set => _gender = value;
        }

        public enum Genders
        {
            Male,
            Female
        }

        public Person(string name, DateTime birthDay, Genders gender)
        {
            _name = name;
            _birthDay = birthDay;
            _gender = gender;
        }

        public override string ToString()
        {
            return $"name: {Name}\n" +
                   $"birth day: {BirthDay}\n" +
                   $"gender: {Gender}\n";
        }
    }
}