using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objet
{
    public class Personnel : IPersonnel
    {
        public Employe[] Employes { get; set; } = new Employe[MAX_EMPLOYE];
        public static int MAX_EMPLOYE = 100;
        public int nbEmploye = 0;

        public void AjouterEmploye(Employe e)
        {
            nbEmploye++;
            if (nbEmploye <= MAX_EMPLOYE)
            {
                Employes[nbEmploye - 1] = e;
            }
            else
            {
                Console.WriteLine("Pas plus de "+MAX_EMPLOYE+" employés");
            }

        }

        public void CalculerSalaire()
        {
            for (int i = 0; i < nbEmploye; i++)
            {
                Console.WriteLine(Employes[i].GetNom()+" gagne "+Employes[i].CalculerSalaire()+" euros");
            }
        }
        public double SalaireMoyen()
        {
            double somme = 0;
            for (int i = 0; i < nbEmploye; i++)
            {
                somme += Employes[i].CalculerSalaire();
            }
            return somme / nbEmploye;
        }
    }
}
