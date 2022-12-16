using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExo.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public Contact()
        {
        }

        public Contact(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }
    }
}
