using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace _1_DemoApi.Filtres
{
    public class MyGlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpStatusCode status;
            string errorMessage;

            var exceptionType = actionExecutedContext.Exception.GetType();
            if (exceptionType == typeof(NullReferenceException))
            {
                status = HttpStatusCode.NotFound;
                errorMessage = "Données indisponibles";
            }
            else if (exceptionType == typeof(UnauthorizedAccessException))
            {
                status = HttpStatusCode.Unauthorized;
                errorMessage = "Action interdit";
            }
            else{
                status = HttpStatusCode.InternalServerError;
                errorMessage = "Contactez l'Admin";
            }

            var reponse = new HttpResponseMessage(status)
            {
                Content = new StringContent(errorMessage),
                ReasonPhrase = "From the server"
            };

            actionExecutedContext.Response = reponse;
        }
    }
}