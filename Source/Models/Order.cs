using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ProductManager.Models;

namespace ProductManager.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(64)]
        public string? Name { get; set; }
        [MaxLength(32)]
        public string? OrderCode { get; set; }
        [MaxLength(128)]
        public string? CustomerEmail { get; set; }
        [MaxLength(320)]
        public string? Image{ get; set; }
        public DateTime CreatedDate { get; set; }
        public int OrderTypeId { get; set; }
        public OrderType? OrderType { get; set; }
    }
}