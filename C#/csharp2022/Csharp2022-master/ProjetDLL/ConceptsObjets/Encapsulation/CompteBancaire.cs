using ProjetDLL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.ConceptsObjets.Encapsulation
{
    [Serializable] //concerne la sérialisation binaire
    [DataContract] //Concerne la sérialisation JSON - Pour obtenir un fichier JSON facile à lire
    public class CompteBancaire : IComparable
    {
        #region Champs - Propriétés

        //Attributs représentent l'état de l'objet

        [DataMember]
        private string _numero;

        public string Numero
        {
            get { return _numero; }
            set 
            { 
                if(value.Length >= 6)
                {
                    _numero = value;
                }
                else
                {
                    //Console.WriteLine("Numéro doit contenir au minimum 6 caractères");
                    throw new Exception("Numéro doit contenir au minimum 6 caractères");
                }
                
            }
        }

        [DataMember]
        public double Solde { get; set; }

        //Attribut globale: partagé par tous les comptes (indépendant des comptes)
        public static string Banque { get; private set; } = "BNP";

        public static int Compteur { get; set; }


        #endregion

        #region "Constructeurs"


        //this(): permet à un contruteur d'appeler un autre contructeur définit dans la mm classe
        //this(): est exécuté en premier
        public CompteBancaire(string numero, double solde):this(numero)
        {
            //Numero = numero;
            Solde = solde;
            //Compteur++;
        }

        //A ne définir sauf en cas de besoin: d'autres classes ou Assembly qui l'exige
        public CompteBancaire()
        {
            Compteur++;
        }

        public CompteBancaire(string Numero):this()
        {
            //this: mot clé qui pointe vers l'objet en cours
            this.Numero = Numero;
            //Compteur++;
        }



        #endregion

        #region "Méthodes"

        //Méthodes représentent le comportement de l'objet
        public void Depot(double montant)
        {
            Solde += montant;
        }

        /// <summary>
        /// Si le sodle n'est pas suffisant, la méthode génère une exception.
        /// </summary>
        /// <param name="montant">un double</param>
        /// <exception cref="SoldeException"></exception>
        public void Retrait(double montant)
        {
            if (Solde >= montant)
            {
                Solde -= montant;
            }
            else
            {
                //Console.WriteLine("Solde insuffisant!!!!!");
                throw new SoldeException("Solde insuffisant pour effectuer un retrait de " + montant);
            }
        }

        //ToString permet de personnaliser l'affichage des objets
        public override string ToString()
        {
            return $"Numéro = {Numero} - Solde = {Solde}";
        }

        public static void ModifierBanque(string nomBanque)
        {
            Banque = nomBanque;
        }

        /* Overload: surchage
* Override: redéfinition de méthodes définies dans la classe mère
*/
       public override bool Equals(object obj)
        {

            if (obj is CompteBancaire)
            {
                CompteBancaire cpt = (CompteBancaire)obj;
                return cpt.Numero == Numero && cpt.Solde == Solde;
            }
            return false;
            //*return obj is CompteBancaire bancaire && Numero == bancaire.Numero &&  Solde == bancaire.Solde;*//*

        }

        /*
         * Cette méthode compare l'objet en cours d'utilisation (this) à l'objet fournit en paramétre à la méthode
         */
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            CompteBancaire cpt = (CompteBancaire)obj;

            return this.Solde.CompareTo(cpt.Solde);
        }





        #endregion

    }
}
