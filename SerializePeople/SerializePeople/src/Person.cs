using System;

namespace SerializePeople
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Genders Gender { get; set; }
        public int Age => DateTime.Now.Year - BirthDate.Year;

        public enum Genders
        {
            Female,
            Male
        }

        public override string ToString()
        {
            return $"Name: {Name}" +
                   $"Birth Date: {BirthDate}" +
                   $"Gender: {Gender}" +
                   $"Age: {Age}";
        }

    }
}