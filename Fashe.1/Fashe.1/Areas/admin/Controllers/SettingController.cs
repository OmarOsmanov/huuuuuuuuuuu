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
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SettingController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(_context.Settings.FirstOrDefault());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Setting model)
        {
            if (ModelState.IsValid)
            {
                if (model.LogoFile.ContentType == "image/jpeg" || model.LogoFile.ContentType == "image/png")
                {
                    if (model.LogoFile.Length <= 3145728)
                    {

                        string fileName = Guid.NewGuid() + "-" + model.LogoFile.FileName;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);


                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            model.LogoFile.CopyTo(stream);
                        }

                        model.Logo = fileName;
                        _context.Settings.Add(model);
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
            return View(_context.Settings.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Setting model)
        {
            if (ModelState.IsValid)
            {
                if (model.LogoFile != null)
                {
                    if (model.LogoFile.ContentType == "image/jpeg" || model.LogoFile.ContentType == "image/png")
                    {
                        if (model.LogoFile.Length <= 3145728)
                        {

                            string oldImage = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", model.Logo);
                            if (System.IO.File.Exists(oldImage))
                            {
                                System.IO.File.Delete(oldImage);
                            }

                            string fileName = Guid.NewGuid() + "-" + model.LogoFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);


                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.LogoFile.CopyTo(stream);
                            }

                            model.Logo = fileName;
                            _context.Settings.Update(model);
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
                    _context.Settings.Update(model);
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

            Setting setting = _context.Settings.Find(id);
            if (setting == null)
            {
                return NotFound();
            }

            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", setting.Logo);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            _context.Settings.Remove(setting);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
