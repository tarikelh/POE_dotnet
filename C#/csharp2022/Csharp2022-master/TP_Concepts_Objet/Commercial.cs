using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objet
{
    public abstract class Commercial : Employe
    {
     
        public float ChiffreAffaire { get; set; }
        protected Commercial(string nom, string prenom, string dateEntree, int age, float chiffreAffaire) : base(nom, prenom, dateEntree, age)
        {
            ChiffreAffaire = chiffreAffaire;
        }

    }
}
