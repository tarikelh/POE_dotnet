using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objets_2
{
    public abstract class Salaries
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        private int _age;

        public int Age
        {
            get { return _age; }
            set
            {
                if (value >= 18 && value<=65)
                {
                    _age = value;
                }
                else
                {
                    //Console.WriteLine("Age est compris entre 18 et 65");

                    throw new Exception("Age est compris entre 18 et 65");
                }
                
            }
        }

        private double _salaire;

        public double Salaire
        {
            get { return _salaire; }
            private set 
            {
                if (value >= 2000)
                {
                    _salaire = value;
                }
                else
                {
                    //Console.WriteLine("Salaire minimum est de 2000");

                    throw new Exception("Salaire minimum est de 2000");
                }
                
            }
        }

        public override string ToString()
        {
            return $"Nom = {Nom} - Prénom = {Prenom} Age = {Age} - Salaire = {Salaire}"; ;
        }

        public abstract void Pointer();

        protected Salaries(string nom, string prenom, int age, double salaire)
        {
            Nom = nom;
            Prenom = prenom;
            Age = age;
            Salaire = salaire;
        }

        public void ModifierSalaire(double nouveauSalaire, Salaries s )
        {
            //Seul le Manager peut modifier le salaire d'un salrié autre qu'un Manager
            if (this is Manager)
            {
                if (s is Manager)
                {
                    Console.WriteLine("Le Manager ne peut pas modifier le salaire d'un autre Manager");
                }
                else
                {
                    s.Salaire = nouveauSalaire;
                    Console.WriteLine("Salaire modifié!!!!!!!");
                }
            }
            else
            {
                Console.WriteLine("Seul le Manager peut modifier le salaire");
            }
        }
    }
}
