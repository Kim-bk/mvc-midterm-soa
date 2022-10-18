using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductManager.Models
{
    public class OrderViewModel
    {
        public List<Order>? Orders { get; set; }
        public SelectList? OrderTypes { get; set; }
        public SelectList? Options { get; set; }
        public string? TypeGenre { get; set; }
        public string? SearchString { get; set; }
        public string? OptionsGenre { get; set; }
    }
}
