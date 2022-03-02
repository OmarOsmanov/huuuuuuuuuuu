using Fashe._1.Data;
using Fashe._1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fashe._1.Areas.admin.Controllers
{
    [Area("admin")]
    public class AboutController : Controller
    {


        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AboutController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(_context.Abouts.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(About model)
        {
            if (ModelState.IsValid)
            {
                if (model.AboutImageFile.ContentType == "image/jpeg" || model.AboutImageFile.ContentType == "image/png")
                {
                    if (model.AboutImageFile.Length <= 3145728)
                    {

                        string fileName = Guid.NewGuid() + "-" + model.AboutImageFile.FileName;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);


                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            model.AboutImageFile.CopyTo(stream);
                        }

                        model.Image = fileName;
                        _context.Abouts.Add(model);
                        _context.SaveChanges();
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        ModelState.AddModelError("", "hecm boyukdur!");
                        return View(model);
                    }



                }
                else
                {
                    ModelState.AddModelError("", "Format uygun deyil!");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }


        public IActionResult Update(int? id)
        {
            return View(_context.Abouts.Find(id));
        }

        [HttpPost]
        public IActionResult Update(About model)
        {
            if (ModelState.IsValid)
            {
                if (model.AboutImageFile != null)
                {
                    if (model.AboutImageFile.ContentType == "image/jpeg" || model.AboutImageFile.ContentType == "image/png")
                    {
                        if (model.AboutImageFile.Length <= 3145728)
                        {

                            string oldImage = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", model.Image);
                            if (System.IO.File.Exists(oldImage))
                            {
                                System.IO.File.Delete(oldImage);
                            }

                            string fileName = Guid.NewGuid() + "-" + model.AboutImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);


                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.AboutImageFile.CopyTo(stream);
                            }

                            model.Image = fileName;
                            _context.Abouts.Update(model);
                            _context.SaveChanges();
                            return RedirectToAction("Index");

                        }
                        else
                        {
                            ModelState.AddModelError("", "hecm boyukdur!");
                            return View(model);
                        }



                    }
                    else
                    {
                        ModelState.AddModelError("", "Format uygun deyil!");
                        return View(model);
                    }
                }

                else
                {
                    _context.Abouts.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("index");
                }
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

            About about = _context.Abouts.Find(id);
            if (about == null)
            {
                return NotFound();
            }

            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", about.Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            _context.Abouts.Remove(about);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}

