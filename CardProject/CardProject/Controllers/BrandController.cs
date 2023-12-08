using CardProject.Models;
using DotNetConnection.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace CardProject.Controllers
{
    public class BrandController:Controller
    {
        private readonly ApplicationDbContext _db;
        public BrandController(ApplicationDbContext db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
  
            return View(_db.Brands.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            if (_db.Brands == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var brands = from m in _db.Brands
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                brands = brands.Where(s => s.BrandName!.Contains(searchString));
            searchString = searchString;
            }
            if (brands.IsNullOrEmpty())
            {

                ViewBag.throwError = "Brand Not Found";
            }
            ViewBag.SearchString = searchString;
            return View(await brands.ToListAsync());
        }
        public IActionResult Create()   
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            var check = _db.Brands.Where(c => c.BrandName == brand.BrandName).FirstOrDefault();
            if (check != null)
            {
                ViewBag.exist = "Already exist";
            }
            else
            {

                _db.Brands.Add(brand);
                _db.SaveChanges();
                ViewBag.message = "brand added successfully";

            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            Brand b = _db.Brands.Find(id);
            return View(b);
        }
        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            

                Brand b = _db.Brands.Find(brand.BrandId);
                b.BrandName = brand.BrandName;
                _db.SaveChanges();
                ViewBag.message = "brand updated successfully!";
                 return View();
        }
    }
}
