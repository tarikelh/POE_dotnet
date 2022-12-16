using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.EX4
{
    public class Porte
    {
        public string Color { get; set; }

        public Porte(string color)
        {
            Color = color;
        }

        public Porte()
        {
        }

        public string Display()
        {
            return $"Je suis une porte, ma couleur est {Color}";
        }
    }
}
