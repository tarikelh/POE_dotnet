using _05_Validations.Models;
using Microsoft.AspNetCore.Mvc;

namespace _05_Validations.Controllers
{
    public class EmployeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult FormValidation()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//Permet de nous protéger des attaquees 
        public async Task<IActionResult> FormValidation(Employe emp)
        {
            if (ModelState.IsValid)
            {
                if(emp.Avatar is not null && emp.Avatar.Length > 0)
                {
                    string upload = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    string filePath = Path.Combine(upload, emp.Avatar.FileName);
                    using(Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await emp.Avatar.CopyToAsync(fileStream);
                    }

                }
                return View("Details", emp);
            }
            return View(emp);
        }
    }
}
