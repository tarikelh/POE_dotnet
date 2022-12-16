using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL
{
    public class Test
    {
        /*Les attributs (variables de classe) possèdent des valeur par defaut - pas besoin de l'initialiser
         * attribut de type numérique (int, double....): 0
         * attribut de type comlpèxe(classe): null
         * attribut boolean: false
         * 
         * 
         */
        public static int x; //pas besoin de l'initiliser contrairement à y - elle possède une valeur par defaut
        public static void Afficher()
        {
            Console.WriteLine("Méthode de la DLL");
            int y = 0;
            Console.WriteLine(y);
            Console.WriteLine(x);
        }
    }
}
