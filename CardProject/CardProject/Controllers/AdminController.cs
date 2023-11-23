using CardProject.Models;
using DotNetConnection.Data;
using Microsoft.AspNetCore.Mvc;

namespace CardProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
           _db = db;
        }
        public IActionResult Login()
        {
            return View();


        }
        [HttpPost]
        public IActionResult Login(Register r )
        {
            var login = _db.Registers.Where(a => a.email == r.email && a.password == r.password).FirstOrDefault();
           if (login != null) {
                HttpContext.Session.SetString("session_user_name", login.Name);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.data = "invalid";
            }
            return View();


        }
        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("session_user_name") == null)
            {
                return RedirectToAction("Login");
            }

            return View();


        }
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("session_user_name")== null)
            {
                return RedirectToAction("Login");
            }

            return View();


        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("session_user_name");
            return RedirectToAction("Login");
        }
    }
}
