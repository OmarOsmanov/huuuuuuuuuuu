using Fashe._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashe._1.ViewModels
{
    public class VmProduct
    {
        public List<Product> Products { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public int PageCount { get; set; }
        public double ItemCount { get; set; }
        public int Page { get; set; }
    }
}
