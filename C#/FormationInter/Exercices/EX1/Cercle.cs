using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices
{
    public class Cercle
    {
        public double Rayon { get; set; }
        private const double PI = 3.14;
        public Cercle()
        {
        }

        public Cercle(double rayon)
        {
            Rayon = rayon;
        }

        
        public float GetArea()
        {
            return (float)(PI *Math.Pow(Rayon, 2));
        }

        public float GetPerimeter()
        {
            return (float)(2*PI *Rayon);
        }

    }
}
