using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objet
{
    public class Representant : Commercial
    {
        public static float BONUS_REPRESENTANT = 800;
        public static float POURCENT_REPRESENTANT = 0.2f;

        public Representant(string nom, string prenom, string dateEntree, int age, float chiffreAffaire) : base(nom, prenom, dateEntree, age, chiffreAffaire)
        {
            
        }

        public override float CalculerSalaire()
        {
            return ChiffreAffaire * POURCENT_REPRESENTANT + BONUS_REPRESENTANT;
        }

        public override string GetNom()
        {
            return "Le représentant " + Prenom + " " + Nom;
        }
    }
}
