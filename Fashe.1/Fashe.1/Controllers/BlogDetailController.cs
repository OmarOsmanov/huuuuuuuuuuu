using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashe._1.Controllers
{
    public class BlogDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
