using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.EX2
{
    public class Teacher : Person
    {
        public string Subject { get; set; }

        public Teacher(string subject)
        {
            Subject = subject;
        }

        public Teacher(int age) : base(age)
        {
        }

        public Teacher()
        {
        }

        public void Explain()
        {
            Console.WriteLine("Explanation begins");
        }
    }
}
