using _3_ClientMVC.ApiClients;
using _3_ClientMVC.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _3_ClientMVC.Controllers
{
    public class LoginController : Controller
    {
         
        private ApiUser api = new ApiUser();
        // GET: Login
        public ActionResult Connexion()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Connexion(LoginDTO loginDTO)
        {
            HttpStatusCode status = await api.CheckLoginAsync(loginDTO);
            if (status == HttpStatusCode.OK)
            {
                Session["loginDTO"] = loginDTO; //Par defaut une session à une durée de 25 min
                //Session.Timeout = 60; // session qui dure 60 mn
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Echec connexion............";
            return View(loginDTO);
        }

        public ActionResult Deconnexion()
        {
            //Session.Clear(); //Supprime toutes les clés

            //Session.Remove("cle1"); //Suppression d'une clé particulière
            Session.Abandon(); //Supprime la session active
            return RedirectToAction("Connexion");
        }

    }
}/*
  * 4 dictionnaires (stockage de type clé:valeur)
  * ViewBag - ViewData: ne maintiennent pas les données. Ils sont remis à zéro dès que la réponse est renvoyée au client
  * 
  * TempData: possède une proriété qui permet de maintenir les données un fois la réponse renvoyée
  * Session: maintient les données pendant toute la durée de la session (par defaut elle dure 20 ou 25 min)
  * 
  */