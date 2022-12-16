using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objet
{
    public class Vendeur:Commercial
    {
        public static float BONUS_VENDEUR = 400;
        public static float POURCENT_VENDEUR = 0.2f;

        public Vendeur(string nom, string prenom, string dateEntree, int age, float chiffreAffaire) : base(nom, prenom, dateEntree, age, chiffreAffaire)
        {
           
        }

        public override float CalculerSalaire()
        {
            return ChiffreAffaire * POURCENT_VENDEUR + BONUS_VENDEUR;
        }

        public override string GetNom()
        {
            return "Le vendeur " + Prenom + " " + Nom;
        }
    }
}
