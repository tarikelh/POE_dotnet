using _1_DemoApi.Filtres;
using _1_DemoApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1_DemoApi.Controllers
{
    [MyGlobalExceptionFilter]
    public class ContactsController : ApiController
    {
        private MyContext context = new MyContext();

        //Liste de contacts

        //GET: api/Contacts

        /// <summary>
        /// Méthode qui renvoie la liste de tous les contacts
        /// </summary>
        /// <returns>Liste de contact</returns>
        //public List<Contact> GetContacts()
        //{
        //    return context.Contacts.ToList();
        //}


        //GET Convention: renvoie le status ok (200) - et des données dans le body
       
        
        public HttpResponseMessage GetContacts()
        {
            List<Contact> lst = context.Contacts.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        //Un contact par son ID
        //GET: api/Contacts/{id}

        /// <summary>
        /// Renvoie le contact par son id
        /// </summary>
        /// <param name="id">est de type in</param>
        /// <returns>Contact</returns>

        //public Contact Get(int id)
        //{
        //    return context.Contacts.Find(id);
        //}

        public HttpResponseMessage Get(int id)
        {
            Contact c = context.Contacts.Find(id);
            if (c != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, c);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Contact avec id = " + id + " introuvable");
            }
        }

        //Insertion d'un contact

        //POST: api/Contacts

        /// <summary>
        /// Méthode qui permet d'insérer un contact
        /// </summary>
        /// <param name="c">Contact JSON à fournir dans le body de la requête</param>

        //public void Post([FromBody] Contact c)
        //{
        //    context.Contacts.Add(c);
        //    context.SaveChanges();
        //}

        //POST Convention: renvoie le status Created (201) + le contact inséré dans le body - eventuellement 
        //ajouter le chemin de la ressource crée dans le header de la réponse

        public HttpResponseMessage Post([FromBody] Contact c)
        {
            try
            {
                context.Contacts.Add(c);
                context.SaveChanges();

                var reponse = Request.CreateResponse(HttpStatusCode.Created, c);

                //Ajouter le chemin dans me header de la réponse
                reponse.Headers.Location = new Uri(Request.RequestUri+"/"+c.Id.ToString());

                return reponse;
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //MAJ d'un contact
        //PUT: api/Contacts/{id}

        /// <summary>
        /// Méthode de mise à jours d'un contact
        /// </summary>
        /// <param name="c">Contact JSON à fournir dans le body de la requête</param>
        /// <param name="id">id du contact à fournir dans l'url de la requête</param>

        //public void Put([FromBody] Contact c, int id)
        //{
        //    Contact contactDB = context.Contacts.Find(id); //Etat = Unchanged
        //    contactDB.Nom = c.Nom;
        //    contactDB.Prenom = c.Prenom; //Etat = Modified
        //    context.SaveChanges();
        //}


        //PUT Convention: status OK (200) + Contact mis à jours dans le body - ou un message dans le body

        public HttpResponseMessage Put([FromBody] Contact c)
        {
            try
            {
                context.Contacts.Attach(c); // etat = unchanged
                context.Entry(c).State = EntityState.Modified;
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, c);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //Suppression d'un contact
        //DELETE: api/Contacts/{id}

        /// <summary>
        /// Méthode de suppression d'un contact
        /// </summary>
        /// <param name="id">est un entier à fournir dans l'url de la requête</param>

        //public void Delete(int id)
        //{
        //    Contact c = context.Contacts.Find(id);
        //    context.Contacts.Remove(c);
        //    context.SaveChanges();
        //}

        //DELETE Convention: Status OK (200) - Le body contient soit l'ID du contact supprimé - ou un message de confirmation

        public HttpResponseMessage Delete(int id)
        {
            Contact c = context.Contacts.Find(id);
            if (c != null)
            {
                context.Contacts.Remove(c);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Contact avec id = "+id+" supprimé.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Contact avec id = " + id + " introuvable.");
            }
        }

    }
}
