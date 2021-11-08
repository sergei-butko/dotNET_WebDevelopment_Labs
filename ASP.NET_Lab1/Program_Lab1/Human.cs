using System;
using System.IO;

namespace Program_Lab1
{
    public class Human
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly int _age;

        protected Human()
        {
            _firstName = "Ivan";
            _lastName = "Ivanov";
            _age = 25;
        }

        protected Human(string firstName, string lastName, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            if (age is <= 0 or > 100)
            {
                throw new InvalidDataException(nameof(age));
            }
            _age = age;
        }
        
        public virtual void Display()
        {
            Console.WriteLine($"Name: {_lastName} {_firstName}. Age: {_age}");
        }
    }
}