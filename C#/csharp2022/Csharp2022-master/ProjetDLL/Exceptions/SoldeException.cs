using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.Exceptions
{
    /*
     * Pour créer des exception personnalisée:
     * 1- Hériter de la classe Exception
     * 2- Appeler le construteur de la classe Exception et lui fournir un message personnalisé
     */
    public class SoldeException : Exception
    {
        public SoldeException(string message):base(message)
        {

        }
    }
}
