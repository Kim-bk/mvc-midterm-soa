using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ProductManager.Models;

namespace ProductManager.Models
{
    public class New
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(128)]
        public string? Title { get; set; }
        [MaxLength(256)]
        public string? Slug { get; set; }
        [MaxLength(1024)]
        public string Content { get; set; }
        [MaxLength(512)]
        public string Image{ get; set; }
        public int TypeNewId { get; set; }
        public TypeNew? TypeNew { get; set; }
    }
}