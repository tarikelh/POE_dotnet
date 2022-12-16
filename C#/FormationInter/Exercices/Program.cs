using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercices.EX2;
using Exercices.EX3;
using Exercices.EX4;

namespace Exercices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******EXO1******");

            Cercle c = new Cercle(6.25);
            Console.WriteLine(c.GetArea());
            Console.WriteLine(c.GetPerimeter());



            Console.WriteLine("******EXO2******");

            Person p = new Person();

            Console.WriteLine("Hello");

            Student s = new Student(15);

            s.GoToClasses();

            Console.WriteLine("Hello");

            s.DisplayAge();
            
            Teacher t = new Teacher(40);

            Console.WriteLine("Hello");

            t.Explain();

            Console.WriteLine("******EXO3******");

            Complex c1 = new Complex(4, 8);
            Complex c2 = new Complex(4, 6);
        
            Console.WriteLine(c1.ToString());
            Console.WriteLine(c2.ToString());

            Console.WriteLine(c2.GetMagnitude());

            Complex c3 = new Complex(-2, 3);

            Console.WriteLine(c2.Sum(c3));


            Console.WriteLine("******EXO4******");

            House a1 = new Apartment(50,new Porte("bleu"));

            Personne p2 = new Personne("DAWAN",a1);
            
            Console.WriteLine(p2.Display()); 



            Console.ReadLine();

        }





    }
}
