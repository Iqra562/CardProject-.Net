using CardProject.Models;
using DotNetConnection.Data;
using Microsoft.AspNetCore.Mvc;

namespace CardProject.Controllers
{
    public class CategoryController:Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            
            return View(_db.Categories.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            var check = _db.Categories.Where(c => c.CategoryName == category.CategoryName).FirstOrDefault();
            if (check != null)
            {
                ViewBag.exist = "Already exist";
            }
            else
            {

                _db.Categories.Add(category);
                _db.SaveChanges();
                ViewBag.message = "category added successfully!";
                      //return RedirectToAction("Index");
            }

            return View();
        }
    }
}
