using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Calculatrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Demander au user de choisir une opération
             * De fournir 2 nombres
             * Afficher le résultat
             * - Gérer le cas d'un choix d'opération non valide
             * - Gérer le cas de nombres fournis non valides
             * - Gérer le cas d'une division par zéro. Vérifier que le nombre2 est différent de zéro
             * 
             */

            string choix = "";
            int nombre1 = 0, nombre2 = 0;

        /*    //Affichage du menu
            Console.WriteLine("*************CALCULATRICE**********");
            Console.WriteLine("- Addition: a");
            Console.WriteLine("- Multiplication: m");
            Console.WriteLine("- Soustraction: s");
            Console.WriteLine("- Division: d");

            //Demander le choix d'une opération. Vérifier que le choix est valide

            

            while (true)
            {
                Console.WriteLine("Choisir une opération:");
                choix = Console.ReadLine();
                if (choix == "a" || choix == "m" || choix == "s" || choix == "d")
                {
                    break;
                }
            }

            //Demander la saisie du 1er nombre. Vérifier qu'il est valide

           

            while (true)
            {
                Console.WriteLine("1er nombre:");

                try
                {
                    nombre1 = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Nombre non valide");
                }
            }

            //Demander la saisie du 2eme nombre. Vérifier qu'il est valide (un nombre différent de 0)

            while (true)
            {
                Console.WriteLine("Second nombre:");

                try
                {
                    nombre2 = Convert.ToInt32(Console.ReadLine());
                    if (nombre2 != 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nombre2 doit être différent de 0");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Nombre non valide");
                }
            }

            //Affichage du résultat

            switch (choix)
            {
                case "a":
                    Console.WriteLine(nombre1 + "+" + nombre2 + "=" + (nombre1 + nombre2));
                    break;
                case "m":
                    Console.WriteLine(nombre1 + "x" + nombre2 + "=" + (nombre1 * nombre2));
                    break;
                case "s":
                    Console.WriteLine(nombre1 + "-" + nombre2 + "=" + (nombre1 - nombre2));
                    break;
                case "d":
                    Console.WriteLine(nombre1 + "/" + nombre2 + "=" + (nombre1 / nombre2));
                    break;
                
            }*/

            Module1.Menu();
            choix = Module2.ChoixOperation();
            nombre1 = Module3.Valeur();
            nombre2 = Module3.Valeur();
            Module4.BoucleSwitch(choix, nombre1, nombre2);

            //Pause
            Console.ReadLine();
        }
    }
}
