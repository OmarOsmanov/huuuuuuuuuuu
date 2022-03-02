using Fashe._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashe._1.ViewModels
{
    public class VmOrder
    {
        public List<SizeColorToProduct> SizeColorToProducts { get; set; }
        public CustomUser CustomUser { get; set; }
    }
}
