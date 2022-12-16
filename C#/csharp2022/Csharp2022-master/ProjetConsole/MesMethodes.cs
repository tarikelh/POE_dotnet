using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole
{
    public class MesMethodes : object
    {
        // visibilité [static] type_du_retour (void) nom_méthode(paramètres) { instructions; }

        //Une classe peut conteni 2 sortes de méthodes:
        //méthode de classe (static): méthode qu'on peut appeler à partir de classe ---- NOM_CLASSE.NOM_METHODE
        //méthode d'instance: méthode qu'on peut appeler à partir d'un objet (d'une instance de classe)


        /// <summary>
        /// Méthode qui affiche une phrase à la console
        /// </summary>
        public static void Afficher()
        {
            Console.WriteLine("Méthode afficher");
        }

        //Surcharge de méthode: pouvoir définir la même méthode dans la même classe en modifiant uniquement la liste des paramétres

        public static void Afficher(string chaine)
        {
            Console.WriteLine(chaine);
        }

        /// <summary>
        /// Méthode qui calcule la somme de 2 entiers
        /// </summary>
        /// <param name="x">est un entier</param>
        /// <param name="y">est un entier</param>
        /// <returns>renvoie la somme de x et y</returns>
        public static int Somme(int x, int y)
        {
            return x + y;
        }

        //Méthode qui liste le contenu d'un tableau
        public static void Afficher(int[] tab)
        {
            foreach (int item in tab)
            {
                Console.WriteLine(item);
            }
        }

        //Méthode qui renvoie la somme des éléments d'un tableau d'entiers

        public static int SommeTab(int[] tab)
        {
            int somme = 0;
            foreach (int item in tab)
            {
                somme += item;
            }

            return somme;
        }

        //Méthode qui renvoie la moyenne des éléments d'un tableau d'entiers

        public static double MoyenneTab(int[] tab)
        {
            double moyenne = 0;
            double somme = 0;
            int taille = tab.Length;
            foreach (var item in tab)
            {
                somme += item;
            }

            moyenne = somme / taille;
            return moyenne;
        }

        //Méthode qui renvoie l'élément le plus petit d'un tableau d'entiers

        public static int MinTab(int[] tab)
        {
            int min = tab[0];
            for (int i = 1; i < tab.Length; i++)
            {
                if (tab[i] < min)
                {
                    min = tab[i];
                }
            }

            return min;
        }

        //Paramétres optionnels: c'est un paramétre qui possède une valeur par defaut et qui définit à la fin de la liste des
        //paramétres

        public static int SommeOptionnelle(int a, int b, int c = 10)
        {
            return a + b + c;
        }

        public static double PrixTTC(double prixHT, double tva = 0.2)
        {
            double tempTVA = prixHT * tva;
            return prixHT + tempTVA; 
        }

        //Méthode qui permute 2 entiers
        //Passage de paramétres par réference: concerne uniquement les types simples (les types complèxes par définition sont des types
        //réference.

        public static void Permuter(ref int x,ref int y)
        {
            int tmp = x;
            x = y;
            y = tmp;
        }

        //Pas besoin du mot clé ref pour les types complèxes

        public static void ModifierTableau(int[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] *= 2;
            }
        }

        //Passage de paramétres en sortie: out
        public static double Calculer(double a, double b, out double produit, out double moyenne)
        {
            produit = a * b;
            moyenne = (a + b) / 2;
            return a + b;
        }

        /*
        public static int Produit(int x, int y)
        {
            return x * y;
        }
        public static int Produit(int x, int y, int z)
        {
            return x * y * z;
        }
        public static int Produit(int x, int y, int z, int w)
        {
            return x * y * z * w;
        }

        */

        //Méthode qui reçoit en params un nombre variables d'arguments: params - permet d'éviter de définir les différentes surcharges

        public static int Produit(params int[] tab)
        {
            int result = 1;
            foreach (int item in tab)
            {
                result *= item;
            }

            return result;

        }

        //Méthode qui renvoie le nombre de mots qui composent une chaine
        public static int NombreMots(string chaine)
        {
            return chaine.Trim().Replace("  ", " ").Split(' ').Length;
        }

        //Méthode qui renvoie la chaine inversée

        public static string InverserChaine(string chaine) //dawan - nawad
        {
            string chaineInverse = "";
            for (int i  = chaine.Length - 1;  i>=0; i--)
            {
                chaineInverse += chaine[i];
            }
            return chaineInverse;
        }

        //Méthode qui vérifie si une chaine est un palindrôme: sos, sms

        public static bool VerifPalindrome(string chaine)
        {
            chaine = chaine.ToUpper();
            return chaine.Equals(InverserChaine(chaine));
        }

        //Méthode qui renvoie le nombre d'occurrences d'un mot dans un paragraphe

        public static int NombreOccurrences(string paragraphe, string mot)
        {
            int nbre = 0;
            string[] tousLesMots = paragraphe.Split(' ', '.', '?', '!', ':');
            foreach (string m in tousLesMots)
            {
                if (m.ToLower().Equals(mot.ToLower()))
                {
                    nbre++;
                }
            }

            return nbre;
        }
    }
}
