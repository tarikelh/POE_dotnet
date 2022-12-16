using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace _05_Serialization
{
    public class Serialization
    {
        public static void ExportBin(string path, List<CompteBancaire> listCB)
        {
            //créer le flux et charger le fichier dessus en mode écriture
            FileStream fs = new FileStream(path, FileMode.Create);

            //Utiliser la classe de sérialisation binaire

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, listCB);
            fs.Close();
        }

        //Méthode de restauration BIN (Lecture du fichier Binaire)

        public static List<CompteBancaire> ImportBin(string path)
        {
            List<CompteBancaire> listCBbin = new List<CompteBancaire>();

            if (File.Exists(path))
            {
                //charger le fichier dansun flux en mode lecture
                FileStream fs = new FileStream(path, FileMode.Open);

                //utilisation de la sérialisation binaire
                BinaryFormatter bf = new BinaryFormatter();
                listCBbin = (List<CompteBancaire>)bf.Deserialize(fs);
                fs.Close();
            }
            else
            {
                throw new Exception("Fichier introuvable");
            }

            return listCBbin;
        }


        public static void ExportXML(string path, List<CompteBancaire> listCB)
        {
            //créer le flux et charger le fichier dessus en mode écriture
            FileStream fs = new FileStream(path, FileMode.Create);

            //Utiliser la classe de sérialisation XML

            XmlSerializer bf = new XmlSerializer(listCB.GetType());
            bf.Serialize(fs, listCB);
            fs.Close();
        }

        //Méthode de restauration XML (Lecture du fichier Binaire)

        public static List<CompteBancaire> ImportXML(string path)
        {
            List<CompteBancaire> listCBXML = new List<CompteBancaire>();

            if (File.Exists(path))
            {
                //charger le fichier dansun flux en mode lecture
                FileStream fs = new FileStream(path, FileMode.Open);

                //utilisation de la sérialisation XML
                XmlSerializer bf = new XmlSerializer(listCBXML.GetType());
                listCBXML = (List<CompteBancaire>)bf.Deserialize(fs);
                fs.Close();
            }
            else
            {
                throw new Exception("Fichier introuvable");
            }

            return listCBXML;
        }

        public static void ExportJSON(string path, List<CompteBancaire> listCB)
        {
            //créer le flux et charger le fichier dessus en mode écriture
            FileStream fs = new FileStream(path, FileMode.Create);

            //Utiliser la classe de sérialisation XML

            DataContractJsonSerializer bf = new DataContractJsonSerializer(listCB.GetType());
            bf.WriteObject(fs, listCB);
            fs.Close();
        }

        //Méthode de restauration XML (Lecture du fichier Binaire)

        public static List<CompteBancaire> ImportJSON(string path)
        {
            List<CompteBancaire> listCBXML = new List<CompteBancaire>();

            if (File.Exists(path))
            {
                //charger le fichier dansun flux en mode lecture
                FileStream fs = new FileStream(path, FileMode.Open);

                //utilisation de la sérialisation XML
                DataContractJsonSerializer bf = new DataContractJsonSerializer(listCBXML.GetType());
                listCBXML = (List<CompteBancaire>)bf.ReadObject(fs);
                fs.Close();
            }
            else
            {
                throw new Exception("Fichier introuvable");
            }

            return listCBXML;
        }

        //Methode de sauvegarde CSV (Ecriture)

        public static void ExportCSV(string path, List<CompteBancaire> listCB)
        {
            StreamWriter sw = new StreamWriter(path);
            string separator = ";";

            foreach (CompteBancaire compteBancaire in listCB)
            {
                sw.WriteLine(compteBancaire.Numero + separator + compteBancaire.Solde);
            }
            sw.Close();
        }

        public static List<CompteBancaire> ImportCSV(string path)
        {
            List<CompteBancaire> listCB = new List<CompteBancaire>();

            if (File.Exists(path))
            {
                int i = 0;
                StreamReader sr = new StreamReader(path);
                //LIre une ligne et la découper
                while (!sr.EndOfStream)
                {
                    CompteBancaire cb = new CompteBancaire();
                    string ligne = sr.ReadLine();

                    ligne = ligne.Trim();
                    string[] values = ligne.Split(';');
                    cb.Numero = values[0];
                    cb.Solde = Convert.ToDouble(values[1]);
                    listCB.Add(cb);
                    Console.WriteLine("LISTCB : " + listCB[i]);
                    i++;
                }
                sr.Close();

            }
            else
            {
                throw new Exception("Fichier CSV introuvable");
            }
            return listCB;
        }
    }
}
