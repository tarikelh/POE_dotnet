using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objets_2
{
    public class Dev : SalarieManager
    {
        public static int ESSAI_DEV = 2;

        public override void Pointer()
        {
            Console.WriteLine($"Dev {Nom} présent.");
        }

        public Dev(string nom, string prenom, int age, double salaire, Manager manager) : base(nom, prenom, age, salaire, manager)
        {
            
        }

    }
}
