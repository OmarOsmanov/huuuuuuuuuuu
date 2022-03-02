using Fashe._1.Data;
using Fashe._1.Models;
using Fashe._1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashe._1.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1, double itemCount = 3)
        {
            VmProduct model = new VmProduct();

            List<Product> products = _context.Products
                                        .Include(cp => cp.ColorToProducts).ThenInclude(pi => pi.ProductImages)
                                        .Include(cp => cp.ColorToProducts).ThenInclude(sc => sc.SizeColorToProducts).ToList();

            model.PageCount = (int)Math.Ceiling(products.Count / itemCount);
            model.Products = products.Skip((page - 1) * (int)itemCount).Take((int)itemCount).ToList();
            model.Page = page;
            model.ItemCount = itemCount;

            return View(model);
        }

        public IActionResult AddToCart(int sizeColorProductId)
        {
            string oldCart = Request.Cookies["cart"];
            string newCart = "";

            if (string.IsNullOrEmpty(oldCart))
            {
                newCart = sizeColorProductId + "";
            }
            else
            {
                List<string> oldCartList = oldCart.Split("-").ToList();
                if (oldCartList.Any(i => i == sizeColorProductId.ToString()))
                {
                    oldCartList.Remove(sizeColorProductId.ToString());
                }
                else
                {
                    oldCartList.Add(sizeColorProductId.ToString());
                }

                newCart = string.Join("-", oldCartList);
            }

            Response.Cookies.Append("cart", newCart);
            return RedirectToAction("Index");
        }

        public IActionResult Cart()
        {
            string cart = Request.Cookies["cart"];
            List<SizeColorToProduct> sizeColorToProducts = new List<SizeColorToProduct>();
            if (!string.IsNullOrEmpty(cart))
            {
                List<string> cartList = cart.Split("-").ToList();

                sizeColorToProducts = _context.SizeColorToProducts.Include(cp => cp.ColorToProduct).ThenInclude(pi => pi.ProductImages)
                                                                  .Include(cp => cp.ColorToProduct).ThenInclude(pi => pi.Product)
                                                                  .Where(sp => cartList.Any(cl => cl == sp.Id.ToString())).ToList();
            }

            return View(sizeColorToProducts);
        }

        public IActionResult Checkout()
        {
            VmOrder model = new VmOrder();
            string cart = Request.Cookies["cart"];
            if (!string.IsNullOrEmpty(cart))
            {
                List<string> cartList = cart.Split("-").ToList();

                model.SizeColorToProducts = _context.SizeColorToProducts.Include(cp => cp.ColorToProduct).ThenInclude(pi => pi.Product)
                                                                  .Where(sp => cartList.Any(cl => cl == sp.Id.ToString())).ToList();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Checkout(VmOrder model)
        {
            string cart = Request.Cookies["cart"];
            List<SizeColorToProduct> sizeColorToProducts = new List<SizeColorToProduct>();
            if (!string.IsNullOrEmpty(cart))
            {
                List<string> cartList = cart.Split("-").ToList();

                sizeColorToProducts = _context.SizeColorToProducts.Include(cp => cp.ColorToProduct).ThenInclude(pi => pi.Product)
                                                                  .Where(sp => cartList.Any(cl => cl == sp.Id.ToString())).ToList();
            }
            var test = model;
            return View();
        }
    }
}

