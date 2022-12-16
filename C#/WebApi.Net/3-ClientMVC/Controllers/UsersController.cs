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
    public class UsersController : Controller
    {
        private ApiUser api = new ApiUser();

        // GET: Users

        [LoginFilter]
        public async Task<ActionResult> Index()
        {
            List<User> lst = await api.GetAllUserAsync();
            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User u)
        {
            await api.AddUserAsync(u);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int id)
        {
            User u = await api.FindByIdAsync(id);
            return View(u);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(User u)
        {
            await api.UpdateUserAsync(u);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            User u = await api.FindByIdAsync(id);
            return View(u);
        }

        public async Task<ActionResult> Delete(int id)
        {
            User u = await api.FindByIdAsync(id);
            return View(u);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirme(int id)
        {
            await api.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }
    }
}