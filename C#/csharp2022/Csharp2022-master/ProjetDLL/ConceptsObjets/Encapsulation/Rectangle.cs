using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.ConceptsObjets.Encapsulation
{
    public class Rectangle
    {
        /*  private double longueur; //champs

          //Accesseurs (getteurs/setteurs) - Propriétés
  *//*
          public double GetLongueur()
          {
              return longueur;    
          }

          public void SetLongueur(double value)
          {
              longueur = value;
          }
  *//*
          public double Longueur
          {
              get { return longueur; }
              set 
              {
                  if (value > 0)
                  {
                      longueur = value;
                  }
                  else
                  {
                      Console.WriteLine("Longueur doit être positive");
                  }

              }
          }*/

        //Longueur possède une contraine - utiliser la propriété full

        private double _longueur;

        public double Longueur
        {
            get { return _longueur; }
            set 
            {
                if (value > 0)
                {
                    _longueur = value;
                }
                else
                {
                    Console.WriteLine("Longueur doit être positive");
                }
                
            }
        }

        //Largeur ne possède pas de contrainte - propriété automatique

        public double Largeur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }


        private int _age;

        public int Age
        {
            private get { return _age; }
            set 
            {
                if (value >= 18 && value <= 60)
                {
                    _age = value;
                }
                else
                {
                    Console.WriteLine("Age est compris entre 18 et 60");
                }
                
            }
        }

        public double Surface()
        {
            return Longueur * Largeur;
        }
    }
}
