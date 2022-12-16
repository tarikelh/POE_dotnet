using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Calculatrice
{
    public class Module3
    {
        public static int Valeur()
        {
            int nombre1 = 0;
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
            return nombre1;

        }
    }
}
