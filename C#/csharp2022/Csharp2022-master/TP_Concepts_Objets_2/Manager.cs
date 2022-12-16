using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objets_2
{
    public class Manager : Salaries
    {
        public Salaries[] Salaries = new Salaries[5];

        public Manager(string nom, string prenom, int age, double salaire) : base(nom, prenom, age, salaire)
        {
        }

        public override void Pointer()
        {
            Console.WriteLine($"Manager {Nom} présent."); ;
        }
     
    }
}
