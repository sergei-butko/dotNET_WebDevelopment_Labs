using System;
using System.IO;

namespace Program_Lab1
{
    public class Student : Human
    {
        private readonly string _name;
        private readonly int _age;
        private readonly string _university;
        
        public Student(string firstName, string lastName, int age, string university)
            : base(firstName, lastName, age)
        {
            _name = $"{lastName} {firstName}";
            if (age is <= 0 or > 100)
            {
                throw new InvalidDataException(nameof(age));
            }
            _age = age;
            _university = university;
        }

        public override void Display()
        {
            Console.WriteLine($"Name: {_name}.\tAge: {_age}.\tUniversity: {_university}");
        }
    }
}