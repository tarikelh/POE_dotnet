using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objets_2
{
    public abstract class SalarieManager : Salaries
    {
        public Manager Manager { get; set; }

        protected SalarieManager(string nom, string prenom, int age, double salaire, Manager manager) : base(nom, prenom, age, salaire)
        {
            Manager = manager;
        }

    }
}
