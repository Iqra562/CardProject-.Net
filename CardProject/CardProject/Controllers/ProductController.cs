﻿using CardProject.Models;
using DotNetConnection.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CardProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment env;
        public ProductController(ApplicationDbContext db,IWebHostEnvironment env)
        {
            this.env = env;
            _db = db;

        }
        public IActionResult Index()
        {
           var conn= _db.Products.Include(a => a.Category).Include(a => a.Brand).ToList();
            return View(conn);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            if (_db.Products == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var products = from m in _db.Products.Include(a => a.Category).Include(a => a.Brand)
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name!.Contains(searchString));
            }
            if (products.IsNullOrEmpty())
            {

                ViewBag.throwError = "Product Not Found";
            }
            ViewBag.SearchString = searchString;
            return View(await products.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewBag.category = new SelectList(_db.Categories, "CategoryId", "CategoryName");
            ViewBag.brand = new SelectList(_db.Brands, "BrandId", "BrandName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product, IFormFile Image)
        {
            
            ViewBag.category = new SelectList(_db.Categories, "CategoryId", "CategoryName");
            ViewBag.brand = new SelectList(_db.Brands, "BrandId", "BrandName");
            string uploadPath = Path.Combine(env.WebRootPath, "images");
            string fileName = Path.Combine(uploadPath, Path.GetFileName(Image.FileName));
            long imageSize = Image.Length; 
            string ext = Path.GetExtension(Image.FileName).Trim('.');

            if (imageSize > 5 * 1024 * 1024)
            {
                ViewBag.imgSizeError = "Unacceptable large file size";
                return View(product);
            }
            if (ext == "png" || ext == "jpeg" || ext == "jpeg" || ext == "avif" || ext == "webp")
            {

                Image.CopyTo(new FileStream(fileName, FileMode.Create));
                product.Image = Image.FileName;
                _db.Products.Add(product);
                _db.SaveChanges();
                ViewBag.message = "product added successfully";
            }
            else
            {

                ViewBag.imgError = "Extension is not available";
                return View(product);
            }


            return View();
        }
        public IActionResult Edit(int id)
        {

            ViewBag.category = new SelectList(_db.Categories, "CategoryId", "CategoryName");
            ViewBag.brand = new SelectList(_db.Brands, "BrandId", "BrandName");
            Product p  = _db.Products.Find(id);
            return View(p);
        }


        [HttpPost]
        public IActionResult Edit(Product p)
        {

            ViewBag.category = new SelectList(_db.Categories, "CategoryId", "CategoryName");
            ViewBag.brand = new SelectList(_db.Brands, "BrandId", "BrandName");
            Product getProduct = _db.Products.Find(p.ProductId);
            getProduct.Name = p.Name;
            getProduct.Price = p.Price;
            getProduct.Quantity = p.Quantity;
            getProduct.BrandId = 1;
            getProduct.CategoryId = 1;
            getProduct.Image = "";
            _db.SaveChanges();
            ViewBag.message = "product updated successfully!";
            return View();
        }
    }
}
