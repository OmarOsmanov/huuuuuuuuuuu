using Fashe._1.Data;
using Fashe._1.Models;
using Fashe._1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fashe._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VmHome model = new VmHome();
            model.Setting = _context.Settings.FirstOrDefault();
            model.Sosials = _context.Sosials.ToList();
            model.Blogs = _context.Blogs.Include(u => u.CustomUser)
                                                   .Include("BlogCategory")
                                                   .OrderByDescending(o => o.CreatedDate)
                                                   .Take(3).ToList();
            return View(model);
        }     
    }
}
