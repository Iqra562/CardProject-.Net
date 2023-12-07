using CardProject.Models;
using DotNetConnection.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            if (_db.Categories == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var categories = from m in _db.Categories
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(s => s.CategoryName!.Contains(searchString));
            }
            if(categories.IsNullOrEmpty())  {

                ViewBag.throwError = "Category Not Found";
            }

            return View(await categories.ToListAsync());
        }

        //[HttpPost]
        //public IActionResult Search(string searchString )
        //{
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        Category category = _db.Categories.Where(s => s.CategoryName.Contains(searchString)).FirstOrDefault();

        //        if (category != null)
        //        {
        //            return View(category);
        //        }
        //        else
        //        {
        //            return View("EntityNotFound");
        //        }
        //    }
        //    return View("Entity not found");
        //}
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
