using _3_ClientMVC.ApiClients;
using _3_ClientMVC.Filtres;
using _3_ClientMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _3_ClientMVC.Controllers
{
  
    public class ContactsController : Controller
    {

        private ApiContact api = new ApiContact();

        // GET: Contacts

        [LoginFilter]
        public async Task<ActionResult> Index()
        {
            List<Contact> lst = await api.GetAllContactAsync();
            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contact c)
        {
            await api.InsertContactAsync(c);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            Contact c = await api.GetByIdAsync(id);
            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Edit(Contact c)
        {
            await api.UpdateContactAsync(c);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            Contact c = await api.GetByIdAsync(id);
            return View(c);
        }

        public async Task<ActionResult> Delete(int id)
        {
            Contact c = await api.GetByIdAsync(id);
            return View(c);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirme(int id)
        {
            await api.DeleteContactAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> CSV()
        {
            byte[] tab = await api.DownloadCsvAsync();
            return File(tab, "text/plain", "contacts.csv");
        }
    }
}