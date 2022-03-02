using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashe._1.ViewModels
{
    public class VmColorImage
    {
        public int ColorId { get; set; }
        public IFormFile[] Image { get; set; }
        public List<string> ImageBase64 = new List<string>();
    }
}
