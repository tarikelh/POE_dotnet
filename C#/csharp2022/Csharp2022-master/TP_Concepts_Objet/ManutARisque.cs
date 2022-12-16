using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objet
{
    public class ManutARisque : Manutentionnaire
    {
        public static int PRIME = 200;

        public ManutARisque(string nom, string prenom, string dateEntree, int age, int heures) : base(nom, prenom, dateEntree, age, heures)
        {
        }

        public override float CalculerSalaire()
        {
            return base.CalculerSalaire() + PRIME;
        }
    }
}
