using ProjetDLL.ConceptsObjets.Encapsulation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetDLL
{
    public class Tools
    {

        //Méthode de lecture d'un fichier - Ajouter l'annotation [Serialiszable] sur la classe CompteBancaire

        public static string LectureFichier(string chemin)
        {
            StreamReader sr = new StreamReader(chemin);
            string contenu = sr.ReadToEnd();
            sr.Close();
            return contenu;
        }

        //Méthode d'écriture dans un fichier

        public static void EcritureFichier(string chemin, string contenu)
        {
            StreamWriter sr = new StreamWriter(chemin, true); //mode ajout
            sr.WriteLine(contenu);
            sr.Close();
        }

        //Méthode de sérialisation BINAIRE: BinaryFormatter

        public static void ExportBIN(string chemin, List<CompteBancaire> lst)
        {
            BinaryFormatter bin = new BinaryFormatter();
            Stream flux = new FileStream(chemin,FileMode.Create);
            bin.Serialize(flux, lst);
            flux.Close();
        }

        //Méthode de désérialisation Binaire

        public static List<CompteBancaire> ImportBIN(string chemin)
        {
            List<CompteBancaire> lst = new List<CompteBancaire>();
            BinaryFormatter bin = new BinaryFormatter();
            Stream flux = new FileStream(chemin, FileMode.Open);
            lst= (List<CompteBancaire>)bin.Deserialize(flux);
            flux.Close();
            return lst;
        }

        //Méthode de sérialisation XML: XmlSerializer

        public static void ExportXML(string chemin, List<CompteBancaire> lst)
        {
            XmlSerializer xml = new XmlSerializer(lst.GetType());
            Stream flux = new FileStream(chemin, FileMode.Create);
            xml.Serialize(flux, lst);
            flux.Close();
        }

        //Méthode de désérialisation XML: XmlSerializer

        public static List<CompteBancaire> ImportXML(string chemin)
        {
            List<CompteBancaire> lst = new List<CompteBancaire>();
            XmlSerializer xml = new XmlSerializer(lst.GetType());
            Stream flux = new FileStream(chemin, FileMode.Open);
            lst = (List<CompteBancaire>)xml.Deserialize(flux);
            flux.Close();
            return lst;
        }

        //Méthode de sérialisation JSON: DataContractJsonSerializer
        //Ajouter l'annotation [DataContract] pour la classe CompteBancaire et [DataMember] pour chaque propriété à sérialiser

        public static void ExportJSON(string chemin, List<CompteBancaire> lst)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(lst.GetType());
            Stream flux = new FileStream(chemin, FileMode.Create);
            json.WriteObject(flux, lst);
            flux.Close();
        }

        //Méthode de désérialisation JSON: DataContractJsonSerializer

        public static List<CompteBancaire> ImportJSON(string chemin)
        {
            List<CompteBancaire> lst = new List<CompteBancaire>();
            DataContractJsonSerializer json = new DataContractJsonSerializer(lst.GetType());
            Stream flux = new FileStream(chemin, FileMode.Open);
            lst = (List<CompteBancaire>)json.ReadObject(flux);
            flux.Close();
            return lst;
        }
    }
}
