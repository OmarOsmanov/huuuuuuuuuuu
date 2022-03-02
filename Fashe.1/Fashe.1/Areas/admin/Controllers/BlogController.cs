using Fashe._1.Data;
using Fashe._1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fashe._1.Areas.admin.Controllers
{
    [Area("admin")/*, Authorize(Roles = "Admin, Moderator")*/]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public BlogController(AppDbContext context, IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(_context.Blogs.OrderByDescending(o => o.CreatedDate).Include(u => u.CustomUser).Include(c => c.BlogCategory).Include(tb => tb.TagToBlogs).ThenInclude(t => t.BlogTag).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.BlogCategories.ToList();
            ViewBag.Tags = _context.BlogTags.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                {
                    if (model.ImageFile.Length <= 3145728)
                    {
                        string fileName = Guid.NewGuid() + "-" + model.ImageFile.FileName;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            model.ImageFile.CopyTo(stream);
                        }

                        model.Image = fileName;
                        model.CreatedDate = DateTime.Now;
                        model.CustomUserId = _userManager.GetUserId(User);
                        _context.Blogs.Add(model);
                        _context.SaveChanges();


                        //Adding Tags to blog
                        foreach (var tagId in model.TagsId)
                        {
                            TagToBlog tagToBlog = new TagToBlog();
                            tagToBlog.TagId = tagId;
                            tagToBlog.BlogId = model.Id;
                            _context.TagToBlogs.Add(tagToBlog);
                        }

                        _context.SaveChanges();

                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can only upload max 3 mb file!");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "You can only upload image file!");
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
            ViewBag.Categories = _context.BlogCategories.ToList();
            ViewBag.Tags = _context.BlogTags.ToList();
            Blog blog = _context.Blogs.Find(id);
            blog.TagsId = _context.TagToBlogs.Where(b => b.BlogId == id).Select(t => t.TagId).ToArray();
            return View(blog);
        }

        [HttpPost]
        public IActionResult Update(Blog model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                    {
                        if (model.ImageFile.Length <= 3145728)
                        {
                            string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", model.Image);
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }

                            string fileName = Guid.NewGuid() + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Image = fileName;
                        }
                        else
                        {
                            ModelState.AddModelError("", "You can only upload max 3 mb file!");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can only upload image file!");
                        return View(model);
                    }
                }

                //Update tags
                //Delete old tag to blogs
                List<TagToBlog> oldTagToBlogs = _context.TagToBlogs.Where(t => t.BlogId == model.Id).ToList();
                foreach (var item in oldTagToBlogs)
                {
                    _context.TagToBlogs.Remove(item);
                }
                _context.SaveChanges();

                //Add new tag to blogs
                foreach (var tagId in model.TagsId)
                {
                    TagToBlog tagToBlog = new TagToBlog();
                    tagToBlog.TagId = tagId;
                    tagToBlog.BlogId = model.Id;
                    _context.TagToBlogs.Add(tagToBlog);
                }

                _context.Blogs.Update(model);
                _context.SaveChanges();
                return RedirectToAction("index");
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
            Blog blog = _context.Blogs.Find(id);
            if (blog == null)
            {
                return NotFound();
            }

            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", blog.Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
