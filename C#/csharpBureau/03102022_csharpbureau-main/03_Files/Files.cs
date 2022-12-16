namespace _03_Files
{
    public class Files
    {
        // static : la méthode est une méthode de classe
        // à ne pas confondre avec une méthode d'instance.
        // La méthode "Write" pourra être appelée directement à partir du nom de la classe (et non pas d'une instance de la classe)
        public static void Write(string path, string contenu, bool append)
        {
            //if (File.Exists(path) == false)
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Fichier \"{path}\" introuvable");
            }

            StreamWriter sw = new StreamWriter(path, append);

            sw.Write(contenu);
            sw.Close();
        }

        public static string Read(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Fichier \"{path}\" introuvable");
            }

            // string contenu ="";

            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
                // sr.Close(); // le flux sera automatiquement fermé grace à la clause "using"
            }

            //return contenu;
        }
    }
}
