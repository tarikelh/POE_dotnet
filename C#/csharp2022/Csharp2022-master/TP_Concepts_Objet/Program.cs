using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objet
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Personnel p = new Personnel();
            p.AjouterEmploye(new Vendeur("Pierre", "Business", "1995", 45, 30000));
            p.AjouterEmploye(new Representant("Léon", "Vendtout",  "2001", 25, 20000));
            p.AjouterEmploye(new Technicien("Yves", "Bosseur",  "1998", 28, 1000));
            p.AjouterEmploye(new Manutentionnaire("Jeanne", "Stocketout",  "1998", 32, 45));
            p.AjouterEmploye(new TechnARisque("Jean", "Flippe",  "2000", 28, 1000));
            p.AjouterEmploye(new ManutARisque("Al", "Abordage",  "2001", 30, 45));
            p.CalculerSalaire();
            Console.WriteLine("Le salaire moyen dans l'entreprise est de " + p.SalaireMoyen() + "  Euros.");

            Employe e = new Vendeur("Pierre", "Business", "1995", 45, 30000);
            e.CompareTo(p);

            //Maintenir la console active
            Console.ReadLine();


        }
    }
}
