using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objet
{
    public abstract class Employe : IComparable
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string DateEntree { get; set; }
        public int Age { get; set; }
        public abstract float CalculerSalaire();
        public virtual string GetNom()
        {
            return "L'employé " + Prenom + " " + Nom;
        }

        public override bool Equals(object obj)
        {
            return obj is Employe employe &&
                   Nom == employe.Nom &&
                   Prenom == employe.Prenom &&
                   Age == employe.Age;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Employe e = (Employe)obj;
            return this.Age.CompareTo(e.Age);
        }

        protected Employe(string nom, string prenom, string dateEntree, int age)
        {
            Nom = nom;
            Prenom = prenom;
            DateEntree = dateEntree;
            Age = age;
        }


    }
}
