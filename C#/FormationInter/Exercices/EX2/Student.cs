using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.EX2
{
    public class Student : Person
    {
        public Student(int age) : base(age)
        {
            
        }

        public Student()
        {
        }

        public void GoToClasses()
        {
            Console.WriteLine("I'm going to class.");
        }

        public void DisplayAge()
        {
            Console.WriteLine($"My age is {Age} years old");
        }
    }
}
