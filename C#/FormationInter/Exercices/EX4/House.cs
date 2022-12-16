using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.EX4
{
    public class House
    {
        public double Surface { get; set; }
        public Porte Porte { get; set; }

        public House(double surface, Porte porte)
        {
            Surface = surface;
            Porte = porte;
        }

        public House(double surface)
        {
            Surface = surface;
        }

        public string Display()
        {
            return $"Je suis une maison, ma surface est de {Surface} m2";
        }

        public Porte GetDoor()
        {
            return Porte;
        }
    }
}
