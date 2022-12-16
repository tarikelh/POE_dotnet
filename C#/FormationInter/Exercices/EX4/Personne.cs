using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.EX4
{
    public class Personne
    {
        public string Nom { get; set; }

        public House Maison { get; set; }
        

        public Personne(string nom, House maison)
        {
            Nom = nom;
            Maison = maison;
        }

        public string Display()
        {
            return $"Je suis {Nom}, ma surface est de {Maison.Surface} m2 et ma porte est {Maison.Porte.Color}";
        }
    }
}
