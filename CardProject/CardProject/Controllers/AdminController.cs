using Microsoft.AspNetCore.Mvc;

namespace CardProject.Controllers
{
    public class AdminController : Controller
    {
      
        public IActionResult Login()
        {
            return View();


        }
        public IActionResult Register()
        {
            return View();


        }
        public IActionResult Dashboard()
        {
            return View();


        }
    }
}
