using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objet
{
    public class TechnARisque : Technicien
    {
        public static int PRIME = 200;

        public TechnARisque(string nom, string prenom, string dateEntree, int age, int unites) : base(nom, prenom, dateEntree, age, unites)
        {
        }

        public override float CalculerSalaire()
        {
            return base.CalculerSalaire() + PRIME;
        }
    }
}
