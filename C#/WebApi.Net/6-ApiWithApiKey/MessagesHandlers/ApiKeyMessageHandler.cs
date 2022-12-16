using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace _6_ApiWithApiKey.MessagesHandlers
{
    public class ApiKeyMessageHandler : DelegatingHandler
    {

        //Déclarer ce Handler dans le fichier Global.asax

        private const string ApiKey = "dawan2022@@@@sdqsdqsdqsdmmpsdqsd";

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Vérifier si la ressource est privée

            if (!RessourcesPubliques().Contains(request.RequestUri.AbsolutePath))
            {
                bool valideKey = false;

                IEnumerable<string> requestHeaders;
                var result = request.Headers.TryGetValues("APIKEY", out requestHeaders);

                if (result)
                {
                    string key = requestHeaders.FirstOrDefault();
                    if (key == ApiKey)
                    {
                        valideKey = true;
                    }
                }
                if (!valideKey)
                {
                    HttpResponseMessage reponse = request.CreateResponse(System.Net.HttpStatusCode.Forbidden, "ApiKey invalide");
                    return reponse;
                }

            }



            //Cette méthode transmet la demande aux controllers
            return await base.SendAsync(request, cancellationToken);
        }

        //Liste de ressources publiques

        static List<string> urls = new List<string>();
        public static List<string> RessourcesPubliques()
        {
            urls.Add("/api/Employes");
            urls.Add("/api/Users/Save");
            urls.Add("/api/check-login");
            return urls;
        }
    }
}