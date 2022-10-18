using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductManager.Models
{
    public class OrderViewModel
    {
        public List<Order>? Orders { get; set; }
        public SelectList? OrderTypes { get; set; }
        public string? TypeGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
