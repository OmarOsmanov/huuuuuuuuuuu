using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fashe._1.Models
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500), Required]
        public string AboutTitle { get; set; }
        [Column(TypeName = "ntext"), Required]
        public string AboutContent { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile AboutImageFile { get; set; }
    }
}
