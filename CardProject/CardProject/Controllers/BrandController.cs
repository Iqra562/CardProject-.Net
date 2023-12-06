﻿using CardProject.Models;
using DotNetConnection.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                ViewBag.message = "Already exist";
            }
            else
            {

                _db.Brands.Add(brand);
                _db.SaveChanges();
                ViewBag.message = "brand is added";

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
