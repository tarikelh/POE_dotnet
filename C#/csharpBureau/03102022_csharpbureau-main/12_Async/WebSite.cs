using System;
using System.Net;
using System.Threading.Tasks;

namespace _12_Async
{
    public class WebSite
    {
        public string Url { get; set; } = string.Empty;

        public string Donnees { get; set; } = string.Empty;

        public static WebSite Download(string url)
        {
            WebSite result = new WebSite();

            WebClient client = new();

            /*
             * On pourrait utiliser la classe HttpClient à la place de WebClient
             * Mais on va pas le faire car HttpClient ne propose que des méthodes asynchrones
             * qui ne nous permettraient pas de mettre en évidence l'intérêt de faire de la progrmaation asynchrone par nous mêmes.
             */

            result.Url = url;
            result.Donnees = client.DownloadString(result.Url);

            return result;
        }

        public static async Task<WebSite> DownloadAsync(string url)
        {
            WebSite result = new WebSite();

            WebClient client = new();

            result.Url = url;

            result.Donnees = await client.DownloadStringTaskAsync(result.Url);

            return result;
        }

        public override string ToString()
        {
            return $"{Url} - taille : {Donnees.Length} caractères.\n";
        }
    }
}
