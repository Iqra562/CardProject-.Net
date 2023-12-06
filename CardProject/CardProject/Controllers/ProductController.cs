﻿using CardProject.Models;
using DotNetConnection.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

            if (imageSize > 5 * 1024 * 1024) 
           {
               ModelState.AddModelError("Image", "The image size exceeds the allowed limit (5MB).");
               return View(product);
           }

            string ext = Path.GetExtension(Image.FileName).Trim('.');
            if (ext == "png" || ext == "jpeg" || ext== "jpeg" || ext == "avif" || ext == "webp")
            {

                Image.CopyTo(new FileStream(fileName, FileMode.Create));
                product.Image = Image.FileName;
                _db.Products.Add(product);
                _db.SaveChanges();
           }
           else
          {

                return View(product);
      }
            

                return View();
        }
    }
}
