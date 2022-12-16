using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.EX2
{
    public class Person
    {
        public int Age { get; set; }

        public Person(int age)
        {
            Age = age;
        }

        public Person()
        {
        }

        public void SetAge(int n)
        {
            Age = n;
            Console.WriteLine($"{n} years old");
        }
    }
}
