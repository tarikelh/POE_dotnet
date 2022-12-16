using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Calculatrice
{
    public class Module2
    {
        public static string ChoixOperation()
        {
            string choix = "";
            while (true)
            {
                Console.WriteLine("Choisir une opération:");
                choix = Console.ReadLine();
                if (choix == "a" || choix == "m" || choix == "s" || choix == "d")
                {
                    break;
                }
            }
            return choix;
        }
    }
}
