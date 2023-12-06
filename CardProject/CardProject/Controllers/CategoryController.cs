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
        public IActionResult Edit(int id)
        {
            Category c = _db.Categories.Find(id);
            return View(c);  

        }
        [HttpPost]
        public IActionResult Edit(Category c)
        {
            
                Category getCategory = _db.Categories.Find(c.CategoryId);
                getCategory.CategoryName = c.CategoryName;
                _db.SaveChanges();
                ViewBag.message = "category updated successfully!";

            

            return View();

        }
    }
}
