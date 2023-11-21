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
                ViewBag.data = "loign";
            }
            else
            {
                ViewBag.data = "invalid";
            }
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
