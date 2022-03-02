﻿using Fashe._1.Data;
using Fashe._1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashe._1.Areas.admin.Controllers
{
    [Area("admin")]
    //[Authorize(Roles = "User")]
    public class BlogCategoryController : Controller
    {
        private readonly AppDbContext _context;

        public BlogCategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.BlogCategories.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogCategory model)
        {
            if (ModelState.IsValid)
            {
                _context.BlogCategories.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Model valid deyil");
                return View(model);
            }
        }

        public IActionResult Update(int id)
        {
            return View(_context.BlogCategories.Find(id));
        }

        [HttpPost]
        public IActionResult Update(BlogCategory model)
        {
            if (ModelState.IsValid)
            {
                _context.BlogCategories.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            BlogCategory category = _context.BlogCategories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            bool IsRelation = _context.Blogs.Any(c => c.BlogCategoryId == category.Id);

            if (IsRelation)
            {
                HttpContext.Session.SetString("CategoryError", "There is some blog related to the category!");
            }
            else
            {
                _context.BlogCategories.Remove(category);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
