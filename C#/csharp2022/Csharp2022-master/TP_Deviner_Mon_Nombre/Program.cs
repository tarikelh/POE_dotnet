using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Deviner_Mon_Nombre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Le programme choisit un nombre aléatoire entre 1 et 100
             * Demander à l'utilisateur de deviner ce nombre.
             * Le user à droit à 6 tentatives.
             * Le programme indique au user si le nombre fournit est inférieur ou supérieur au nombre alétoire
             * Si le user trouve le bon nombre, le programme affichera le nombe alétoire + le nombre de tentatives.
             * Le programme gèrera le cas où la valeur saisie à la console n'est pas un nombre
             * 
             * 
             * 
             */

            Console.WriteLine("************DEVINER MON NOMBRE***********");
            Random random = new Random();
            int nombre = random.Next(1,100) ;
            const int NB_TENTATIVE_MAX = 6;
            int nb_tentative = 0;

            //demander au user de fournir un nombre

            while (true)
            {
                Console.WriteLine("Votre nombre:");
                nb_tentative++;
                try
                {
                    int saisi = Convert.ToInt32(Console.ReadLine());

                    if (nb_tentative == NB_TENTATIVE_MAX)
                    {
                        Console.WriteLine($"Perdu!!! Vous avez atteint le nombre de tentatives max. Nombre aléatoire = {nombre}");
                        break;
                    }

                    if (saisi == nombre)
                    {
                        Console.WriteLine($"Trouvé en {nb_tentative} tentatives. Mon est {nombre}");
                        break;
                    }

                    if (saisi < nombre)
                    {
                        Console.WriteLine("Plus grand");
                    }

                    if (saisi > nombre)
                    {
                        Console.WriteLine("Plus petit");
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Saisir uniquement des nombres");
                }
            }

           

            //Maintenir la console active
            Console.ReadLine(); 
        }
    }
}
