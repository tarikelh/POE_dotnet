using ProjetDLL.ConceptsObjets.Encapsulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.Comparateurs
{
    public class SoldeDecroissant : IComparer<CompteBancaire>
    {
        public int Compare(CompteBancaire x, CompteBancaire y)
        {
            if(x.Solde == y.Solde)
            {
                return 0;
            }

            else if (x.Solde < y.Solde)
            {
                return 1;
            }

            else 
            {
                return -1;
            }
        }
    }
}
