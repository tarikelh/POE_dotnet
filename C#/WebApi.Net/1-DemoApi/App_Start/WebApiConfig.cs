using _1_DemoApi.Formatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace _1_DemoApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services de l'API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            /*
             * Une API REST n'est limités au format JSON. Le server gère une collection de formats.
             * Pour limiter le contenu au format JSON, il suffit de supprimer le format XML de cette collection
             */

            //Limiter le type de retour au format JSON - Suppression du format XML
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //Ajout du format csv dans la collection
            config.Formatters.Add(new CsvMediaTypeFormatter());

        }
    }
}
