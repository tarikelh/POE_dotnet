using _5_ApiProductWithImage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace _5_ApiProductWithImage.Controllers
{
    public class ProduitsController : ApiController
    {
        private MyContext context = new MyContext();

        [HttpGet]
        [Route("api/Produits")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, context.Produits.ToList());
        }

        [HttpPost]
        [Route("api/Produits")]
        public HttpResponseMessage Post()
        {

            //Créer un dossier à la racine du projet pour stocker les images des produits
           //string path = HttpContext.Current.Server.MapPath("~/Images/");
           string path = @"C:\Users\Admin\Desktop\WebServicesNet\1-DemoApi\3-ClientMVC\Content\images\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Récuperer le produit fournit via la requête
            string produitStringJSON = HttpContext.Current.Request.Form["produit"];

            //Convertir produitStringJson en objet de type produit

            Produit p = JsonConvert.DeserializeObject<Produit>(produitStringJSON);

            //Récupérer l'image depuis le formulaire

            HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

            //Sauvegarde du fichier dans le dossier images en modifiant son nom -
            //pour le nom de l'image choisir un attribut unique dans la classe produit

            int idMax;
            if (context.Produits.ToList().Count == 0)
            {
                idMax = 0;
            }
            else
            {
                idMax = context.Produits.Max(pr => pr.Id);
            }
           
            string fileName = (idMax+1) + Path.GetExtension(postedFile.FileName); //pc dell.jpg

            postedFile.SaveAs(path + fileName);
            p.Image = fileName;

            context.Produits.Add(p);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created, p);

        }
        [HttpGet]
        [Route("api/Produits/Image/{id}")]
        public HttpResponseMessage GetProduitImage(int id)
        {
            //string path = HttpContext.Current.Server.MapPath("~/Images/");
            string path = @"C:\Users\Admin\Desktop\WebServicesNet\1-DemoApi\3-ClientMVC\Content\images\";
            Produit p = context.Produits.Find(id);
            byte[] b = File.ReadAllBytes(path+p.Image);

            HttpResponseMessage reponse = new HttpResponseMessage();
            reponse.Content = new ByteArrayContent(b);
            reponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
            reponse.Content.LoadIntoBufferAsync(b.Length).Wait();

            return reponse;
        }

        [HttpGet]
        [Route("api/Produits/{id}")]
        public HttpResponseMessage GetProduitById(int id)
        {
           
            Produit p = context.Produits.Find(id);

            return Request.CreateResponse(HttpStatusCode.OK, p);
        }

        [HttpPut]
        [Route("api/Produits")]
        public HttpResponseMessage Put()
        {

            //Créer un dossier à la racine du projet pour stocker les images des produits
            //string path = HttpContext.Current.Server.MapPath("~/Images/");
            string path = @"C:\Users\Admin\Desktop\WebServicesNet\1-DemoApi\3-ClientMVC\Content\images\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Récuperer le produit fournit via la requête
            string produitStringJSON = HttpContext.Current.Request.Form["produit"];

            //Convertir produitStringJson en objet de type produit

            Produit p = JsonConvert.DeserializeObject<Produit>(produitStringJSON);

            //Récupérer l'image depuis le formulaire

            HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

            //Sauvegarde du fichier dans le dossier images en modifiant son nom -
            //pour le nom de l'image choisir un attribut unique dans la classe produit

       

            string fileName = p.Id + Path.GetExtension(postedFile.FileName); //pc dell.jpg

            postedFile.SaveAs(path + fileName);
            p.Image = fileName;

            context.Produits.Attach(p);
            context.Entry(p).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, p);

        }

        [HttpDelete]
        [Route("api/Produits/Delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            Produit p = context.Produits.Find(id);
            context.Produits.Remove(p);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Produit supprimé");
        }


    }
}
