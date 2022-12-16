using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.ConceptsObjets.Agregation
{
    public class Client
    {
        public string Nom { get; set; }
        public Adresse Adresse { get; set; } 
        //Un objet de type adresse fait partie des attributs d'un objet de type client
        //On parle d'association d'objets

        public Client(string nom, Adresse adresse)
        {
            Nom = nom;
            Adresse = adresse;
        }

        public Client()
        {
        }
    }
}
