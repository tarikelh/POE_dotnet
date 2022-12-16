using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.ConceptsObjets.Agregation
{
    public class Adresse
    {
        public int Numero { get; set; }
        public string Street { get; set; }

        public Adresse(int numero, string street)
        {
            Numero = numero;
            Street = street;
        }

        public Adresse()
        {
        }
    }
}
