using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objets_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Salaries> lstsalaries = new List<Salaries>();
            lstsalaries.Add(new Manager("nom", "prenom", 45, 5000));
            lstsalaries.Add(new Manager("nom", "prenom", 35, 4000));
            lstsalaries.Add(new Manager("nom", "prenom", 30, 3300));

            foreach(Salaries salaries in lstsalaries)
            {
                Console.WriteLine(salaries);
            }

            Manager manager = new Manager("nom", "prenom", 45, 4500);
            Dev dev = new Dev("nom", "prenom", 25, 2000, manager);
            //dev.Salaire = 4000;

            manager.ModifierSalaire(3500, dev);

            Console.WriteLine($"Nouveau salaire = {dev.Salaire}");

            //Pause
            Console.ReadLine();
        }
    }
}
