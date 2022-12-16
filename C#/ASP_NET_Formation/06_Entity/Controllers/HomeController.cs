using System.Diagnostics;
using _06_Entity.Models;
using _06_Entity.Services;
using _06_Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace _06_Entity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _mail;


        public HomeController(ILogger<HomeController> logger, IEmailService mail)
        {
            _logger = logger;
            _mail = mail;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> Contact(EmailViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _mail.SendEmailAsync(vm);
                TempData["success"] = "Message sent succesfully";
                return View("Index");
            }
            
            return View();

        }
    }
}