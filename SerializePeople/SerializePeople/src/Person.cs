using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace SerializePeople
{
    [Serializable]
    public class Person : ISerializable
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Genders Gender { get; set; }

        public int Age
        {
            get { return DateTime.Now.Year - BirthDate.Year; }
            set { Age = value; }
        }

        public enum Genders
        {
            Female,
            Male
        }

        public void Serialize(string output)
        {
            using (Stream stream = File.Open(output, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, this);
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("BirthDate", BirthDate);
            info.AddValue("Gender", Gender);
            info.AddValue("Age", Age);
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Birth Date: {BirthDate}\n" +
                   $"Gender: {Gender}\n" +
                   $"Age: {Age}";
        }
    }
}