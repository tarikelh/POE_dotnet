using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.ConceptsObjets.Heritage
{
    public class Chat : Animal
    {
        //Base mot clé qui pointe vers la classe mère

        public string Race { get; set; }
        public Chat(string nom, int age, string race):base(nom, age)
        {
            Race = race;
        }

        public Chat()
        {
        }

        //Redéfinition de la méthode Identite définie dans la classe mère
        public override void Identite()
        {
            Console.WriteLine("Je suis un chat");
        }
    }
}
