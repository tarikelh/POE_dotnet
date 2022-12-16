using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objets_2
{
    public class Consultant:SalarieManager
    {
        public static int ESSAI_CONSULTANT = 3;

        public override void Pointer()
        {
            Console.WriteLine($"Consultant {Nom} présent."); 
        }


        public Consultant(string nom, string prenom, int age, double salaire, Manager manager) : base(nom, prenom, age, salaire, manager)
        { 
        }

    }
}
