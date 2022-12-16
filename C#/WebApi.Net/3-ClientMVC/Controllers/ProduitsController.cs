using _3_ClientMVC.ApiClients;
using _3_ClientMVC.Filtres;
using _3_ClientMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _3_ClientMVC.Controllers
{
    public class ProduitsController : Controller
    {
        private ApiProduit api = new ApiProduit();
        // GET: Produits

        [LoginFilter]
        public async Task<ActionResult> Index()
        {
            List<Produit> lst = await api.GetAllProducts();

           
            return View(lst);
        }

        public async Task<ActionResult> Edit(int id)
        {
            Produit p = await api.GetProduitById(id);
            byte[] prodImage = await api.GetImageProduitAsync(id);
            Session["prodImage"] = prodImage;
            return View(p);
        }
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Exclude ="Image")]Produit p, HttpPostedFileBase image)
        {
            string produitJsonString = JsonConvert.SerializeObject(p);

            //Insertion du produitJson dans le multipartdata
            MultipartFormDataContent multipart = new MultipartFormDataContent();
            multipart.Add(new StringContent(produitJsonString), "produit");

            //Insertion de l'image dans le multipartdata
            if (image == null)
            {
                byte[] tab = (byte[])Session["prodImage"];
                image = new MemoryPostedFile(tab, "image/jpg", "image.jpg");
            }
            var fileStreamContent = new StreamContent(image.InputStream);
            fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(image.ContentType);

            multipart.Add(fileStreamContent, "image", image.FileName);


            await api.UpdateAsync(multipart);
           

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirme(int id)
        {
            await api.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Exclude = "Image")] Produit p, HttpPostedFileBase image)
        {
            string produitJsonString = JsonConvert.SerializeObject(p);

            //Insertion du produitJson dans le multipartdata
            MultipartFormDataContent multipart = new MultipartFormDataContent();
            multipart.Add(new StringContent(produitJsonString), "produit");

            //Insertion de l'image dans le multipartdata
            if (image == null)
            {
                ViewBag.Message = "Choisir une image jpg";
                return View(p);
            }
            var fileStreamContent = new StreamContent(image.InputStream);
            fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(image.ContentType);

            multipart.Add(fileStreamContent, "image", image.FileName);


            await api.AddProductAsync(multipart);


            return RedirectToAction("Index");
        }
    }
}