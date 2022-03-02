using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fashe._1.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250), Required(ErrorMessage = "Qaqa title yaz")]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [Column(TypeName = "nText"), Required]
        public string Content { get; set; }
        [ForeignKey("BlogCategory"), Required]
        public int BlogCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("CustomUser")]
        public string CustomUserId { get; set; }
        [NotMapped]
        public int[] TagsId { get; set; }
        public CustomUser CustomUser { get; set; }
        public List<TagToBlog> TagToBlogs { get; set; }
        public List<Comment> Comments { get; set; }

       
    }
}
