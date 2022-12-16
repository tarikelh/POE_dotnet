using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3_ClientMVC.Filtres
{
    public class LoginFilter : ActionFilterAttribute
    {
        //Vérifier si la Session est vide - si un User est connecté
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Session["loginDTO"] == null)
            {
                //Aucun user connecté - Afficher la page de connexion
                filterContext.HttpContext.Response.Redirect("~/Login/Connexion");
            }
            
        }
    }
}