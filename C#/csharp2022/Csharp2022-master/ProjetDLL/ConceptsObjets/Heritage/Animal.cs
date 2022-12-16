using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.ConceptsObjets.Heritage
{
    public class Animal
    {
        public string Nom { get; set; }
        public int Age { get; set; }

        public Animal(string nom, int age)
        {
            Nom = nom;
            Age = age;
        }

        public Animal()
        {
        }

        //Virtual: mot clé qui permet aux classes enfants de redéfinir cette méthode
       public virtual void Identite()
        {
            Console.WriteLine("Je suis un animal");
        }

        private void MethodePrivee()
        {

        }
    }
}
