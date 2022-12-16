using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objet
{
    public class Technicien : Employe
    {
        public int Unites { get; set; }
        public static float FACTEUR_UNITE = 5;

        public Technicien(string nom, string prenom, string dateEntree, int age, int unites) : base(nom, prenom, dateEntree, age)
        {
            Unites = unites;
        }

        public override float CalculerSalaire()
        {
            return Unites * FACTEUR_UNITE;
        }

        public override string GetNom()
        {
            return "Le technicien " + Prenom + " " + Nom;
        }
    }
}
