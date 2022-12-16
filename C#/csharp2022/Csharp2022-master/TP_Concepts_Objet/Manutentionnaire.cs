using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objet
{
    public class Manutentionnaire : Employe
    {
        public int Heures { get; set; }
        public static float SALAIRE_HORAIRE = 65;

        public Manutentionnaire(string nom, string prenom, string dateEntree, int age, int heures) : base(nom, prenom, dateEntree, age)
        {
            Heures = heures;
        }

        public override float CalculerSalaire()
        {
            return Heures * SALAIRE_HORAIRE;
        }

        public override string GetNom()
        {
            return "Le manutentionnaire " + Prenom + " " + Nom;
        }
    }
}
