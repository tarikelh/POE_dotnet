using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.EX3
{
    public class Complex
    {

        public int Vr { get; set; }
        public int Vi { get; set; }

        public Complex(int vr, int vi)
        {
            Vr = vr;
            Vi = vi;
        }

        public override string ToString()
        {
            return $"Le nombre est: ({Vr}, {Vi})";
        }

        public string GetMagnitude()
        {
            var magnitude= Math.Sqrt(Math.Pow(Vr,2) + Math.Pow(Vi,2));
            return $"L'ordre de grandeur: {magnitude}";
        }

        public string Sum(Complex nbc)
        {
            int partie_r = this.Vr + nbc.Vr;
            int partie_i = this.Vi + nbc.Vi;
            return $"Après l'addition : ({partie_r},{partie_i})";
        }
    }
}
