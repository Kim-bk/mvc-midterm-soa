using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManager.Models
{
    public class OrderType
    {
        public OrderType(){
            Orders = new List<Order>();
        }
        public int OrderTypeId { get; set; }
        public string? OrderTypeName { get; set; }
        public List<Order> Orders { get; set; }
    }
}