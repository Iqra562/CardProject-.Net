using DotNetConnection.Data;
using Microsoft.AspNetCore.Mvc;

namespace CardProject.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ClientController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var products = _db.Products.Skip(1).Take(5).ToList();

            return View(products);
        }
    }
}
