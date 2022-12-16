using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Calculatrice
{
    public class Module4
    {
        public static void BoucleSwitch(string choix, int nombre1, int nombre2)
        {
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

            }
        }
    }
}
